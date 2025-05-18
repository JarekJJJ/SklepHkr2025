using Microsoft.AspNetCore.SignalR;
using SklepHkr2025.Data;
using SklepHkr2025.Data.Entity.Incom;
using SklepHkr2025.Model.Incom;
using System.Xml;

namespace SklepHkr2025.Services.Incom
{
    public class IncomService : IIncomService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<ProgressHub> _hubContext;
        public IncomService(ApplicationDbContext context, IHubContext<ProgressHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        public async Task AddIncomGroup(string connectionId)
        {
            // List<IncomGroupForListVm> incomGroups = new List<IncomGroupForListVm>();
            var filePath = Path.Combine("wwwroot", "Files", "xml", "incomGroupTemp.xml");
            if (!File.Exists(filePath))
            {
                // Możesz wysłać informację o błędzie do klienta przez SignalR
                await _hubContext.Clients.Client(connectionId)
                    .SendAsync("ProgressUpdate", 0, 0, 0, "Plik XML nie istnieje.");
                return;
            }
            int total = 0, processed = 0;
            int batchSize = 100;
            var batch = new List<GrupyIncom>(batchSize);
            using (var countReader = XmlReader.Create(filePath, new XmlReaderSettings { Async = true })) //Liczenie ile jest rekordów statystycznie dla postępu !
            {
                while (await countReader.ReadAsync())
                {
                    if (countReader.NodeType == XmlNodeType.Element && countReader.Name == "grupy")
                        total++;
                }
            }
            _context.GrupyIncom.RemoveRange(_context.GrupyIncom);
            await _context.SaveChangesAsync();
            using (var stream = File.OpenRead(filePath))
            using (var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true }))
            {
                while (await reader.ReadAsync())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "grupy") //sprawdza, czy aktualny węzeł to początek elementu <grupy>. Każdy taki element reprezentuje jedną grupę do zaimportowania.
                    {
                        string? id = null, idh = null, name = null;
                        using (var grupyReader = reader.ReadSubtree()) //  tworzy nowy czytnik XML ograniczony tylko do bieżącego elementu <grupy> i jego dzieci.
                        {
                            await grupyReader.ReadAsync(); // Ustawia na <grupy>
                            while (await grupyReader.ReadAsync()) // przechodzi po wszystkich podwęzłach <grupy>.
                            {
                                if (grupyReader.NodeType == XmlNodeType.Element) //sprawdza, czy aktualny węzeł to element (np. <id>, <idh>, <name>
                                {
                                    var elementName = grupyReader.Name; // zapamiętuje nazwę elementu.
                                    if (await grupyReader.ReadAsync() && grupyReader.NodeType == XmlNodeType.Text) //sprawdza, czy można odczytać wartość tekstową elementu.
                                    {
                                        // W zależności od nazwy elementu, przypisuje wartość do odpowiedniej zmiennej.
                                        // Używa switch-case dla lepszej czytelności i wydajności.
                                        // Można to również zrobić za pomocą if-else, ale switch-case jest bardziej przejrzysty w tym przypadku.
                                        {
                                            switch (elementName)
                                            {
                                                case "id":
                                                    id = grupyReader.Value;
                                                    break;
                                                case "idh":
                                                    idh = grupyReader.Value;
                                                    break;
                                                case "name":
                                                    name = grupyReader.Value;
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(name))
                            {
                                batch.Add(new GrupyIncom
                                {
                                    IdGroup = id,
                                    IdMainGroup = idh,
                                    Name = name
                                });
                            }
                            //
                            processed++; // inkrementuje licznik przetworzonych rekordów.
                            if (batch.Count >= batchSize || processed == total) //sprawdza, czy osiągnięto rozmiar wsadu lub przetworzono wszystkie rekordy.
                            {
                                _context.GrupyIncom.AddRange(batch); //dodaje wsad do kontekstu.
                                await _context.SaveChangesAsync(); //zapisuje zmiany w bazie danych.
                                batch.Clear(); //czyści wsad.

                                int percent = total > 0 ? (int)((double)processed / total * 100) : 0; // oblicza procent przetworzonych rekordów.
                                await _hubContext.Clients.Client(connectionId) // wysyła aktualizację postępu do klienta.
                                .SendAsync("ProgressUpdate", percent, processed, total);//Wysyła postęp do klienta przez SignalR – informuje użytkownika o aktualnym stanie przetwarzania.
                            }
                        }
                    }
                }
            }
        }
    }
}
