using System;
using Telegram.Bot;

namespace TelegramTestBoot
{
    class Program
    {
        static ITelegramBotClient _botClient;
        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("1656435902:AAEB4uMRPd5g6ZU6Nq494Iy9gtY12H9NCSM");
            var me = _botClient.GetMeAsync().Result;
            Console.WriteLine($"Hi, I am {me.Id} and my name is: {me.FirstName}");

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();

            System.Console.WriteLine("Please enter any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();
        }
        private async static void _botClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                System.Console.WriteLine($"Message Received"); 
            
                if (e.Message.Text.ToLower().Contains("hola"))
                {
                  await _botClient.SendTextMessageAsync(chatId: e.Message.Chat.Id, text: $"Coño tu otra vez?");
                  System.Console.WriteLine($"Message send");  
                }
                else if (e.Message.Text.ToLower().Contains("contacto"))
                {
                  await _botClient.SendContactAsync(chatId: e.Message.Chat.Id, phoneNumber: "(+58) 424778906", firstName: "John", lastName: "Wick");
                }
            }
            else if (e.Message.Sticker != null)
            {
                System.Console.WriteLine($"StickerS Received");
                await _botClient.SendStickerAsync(chatId: e.Message.Chat.Id, sticker:"https://tlgrm.eu/_/stickers/ee1/7e3/ee17e34b-083f-3cae-b8de-24e96558758b/thumb-animated-128.mp4"); 
            }
        }
    }
}
