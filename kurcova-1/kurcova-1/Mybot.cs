using kurcova_1.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Microsoft.VisualBasic;
using kurcova_1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace kurcova_1
{
    internal class Mybot
    {
        public string operation { get; set; }   

        TelegramBotClient botClient = new TelegramBotClient("6259809045:AAFtQw1pADPraiaNfT6cChh8nxVi4cU5mj0");
        UserText umessage = new UserText();
        MyRecipes MyRecipes = new MyRecipes();
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

        public async Task Start()
        {
            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await botClient.GetMeAsync();
            Console.WriteLine($"{botMe.Username} Bot has just started working");
            Console.ReadKey();
        }
   
        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Помилка в телеграм бот АПІ:\n {apiRequestException.ErrorCode}" +
                $"\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandlerMessageAsync(botClient, update.Message);
            }
          

        }
        
        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
        {
            
            if (message.Text == "/start")
            {
                
                long userId = message.Chat.Id;
                string username = message.Chat.Username;

                Console.WriteLine($"Получено {username} повідомлення від  (ID: {userId})");


                //await botClient.SendTextMessageAsync(message.Chat.Id, "Вітаю, Я - Bonny! \r\nЯ створений, щоб надати вам смачні та кулінарні інсайти. Незалежно від того, чи ви шукаєте ідею для обіду, святкової страви або просто хочете спробувати щось нове, я готовий допомогти!\r\n");
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вітаю, Я - Bonny! 😊\r\nЯ створений, щоб надати вам смачні та кулінарні інсайти. 🍽️🍳 Незалежно від того, чи ви шукаєте ідею для обіду, святкової страви або просто хочете спробувати щось нове, я готовий допомогти! 🎉👩‍🍳👨‍🍳");
                //await botClient.SendTextMessageAsync(message.Chat.Id, "За допомогою мене ви можете:\r\n1) Якщо ви бажаєте приготувати щось смачне до обіду, сніданку або вечері, тоді скористайтесь функцією пошуку існуючої страви та її рецепту.\r\n2) Також за бажанням ви можете подивитися калорійність страви, яка вас цікавить.\r\n3) На випадок, якщо ви захочете спробувати приготувати щось за власним рецептом, ви можете скористатися функцією додавання власної страви разом з її рецептом.\r\n4) Іноді не виходить зробити все добре з першого разу, тому я можу надати вам можливість видаляти або змінювати ваші рецепти.\r\n5) Коли у вас буде настільки багато страв, що ви будете в них плутатись, я маю функцію, яка дозволить вам побачити всі ваші страви за назвою.\r\n6) Не один раз може трапитись таке, що ви можете забути, що необхідно для того, щоб приготувати вашу страву. На цей випадок у мене є функція, яка знайде серед ваших страв та їх рецептів, рецепт страви за назвою.");
                await botClient.SendTextMessageAsync(message.Chat.Id, "За допомогою мене ви можете:\r\n\r\n🍽️ Якщо ви бажаєте приготувати щось смачне до обіду, сніданку або вечері, тоді скористайтесь функцією пошуку існуючої страви та її рецепту.\r\n🔥 Також за бажанням ви можете подивитися калорійність страви, яка вас цікавить.\r\n👩‍🍳 На випадок, якщо ви захочете спробувати приготувати щось за власним рецептом, ви можете скористатися функцією додавання власної страви разом з її рецептом.\r\n✏️ Іноді не виходить зробити все добре з першого разу, тому я можу надати вам можливість видаляти або змінювати ваші рецепти.\r\n📋 Коли у вас буде настільки багато страв, що ви будете в них плутатись, я маю функцію, яка дозволить вам побачити всі ваші страви за назвою.\r\n🔍 Не один раз може трапитись таке, що ви можете забути, що необхідно для того, щоб приготувати вашу страву. На цей випадок у мене є функція, яка знайде серед ваших страв та їх рецептів, рецепт страви за назвою. ");

                ReplyKeyboardMarkup replyKeyboardMarkup = new
                   (
                   new[]
                       {
                        new KeyboardButton[] { "🔍 Пошук страви 🔍" },
                        new KeyboardButton[] { "🍳📚 Моя кулінарна книга" },
                        new KeyboardButton[] { "🍽️🔥 Калорійність страви 🍽️🔥" }
                       }
                   )
                {
                    ResizeKeyboard = true
                }; 
                await botClient.SendTextMessageAsync(message.Chat.Id, "Чим я можу вам допомогти?😇", replyMarkup: replyKeyboardMarkup);
                return;
            }

            else if (message.Text == "🔍 Пошук страви 🔍")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Наша база рецептів створена на англійській мові.\r\nТому просимо вводити назву англійською)");
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вкажіть назву страви : ");
                operation = "EnterStartRecipe";

            }
            else if (message.Text == "🍳📚 Моя кулінарна книга")
            {
               
                ReplyKeyboardMarkup replyKeyboardMarkup = new
                   (
                   new[]
                       {
                        new KeyboardButton[] { "🔎 Пошук рецепту ", "📚 Переглянути рецепти " },                        
                        new KeyboardButton[] { "➕ Додавання рецепту ", "❌ Видалити рецепт "},                      
                        new KeyboardButton[] { "🔄 Оновити дані рецепту "},
                        new KeyboardButton[] { "Назад ↩️"},
                       }
                   )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть опцію : ", replyMarkup: replyKeyboardMarkup);
                return;
            }
            else if(message.Text == "🍽️🔥 Калорійність страви 🍽️🔥")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Наша база рецептів створена на англійській мові.\r\nТому просимо вводити назву англійською)");
                await botClient.SendTextMessageAsync(message.Chat.Id, "Вкажіть назву страви : ");
                operation = "EnterStartCaloriesRecipe";
            }
            else if(message.Text == "🔎 Пошук рецепту")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть назву рецепту :");
                operation = "SearchRecipe";
            }
            else if (message.Text == "📚 Переглянути рецепти")
            {
                MyRecipes.Id = message.Chat.Id;
                DisplayRecipes(botClient, message, MyRecipes.Id);
            }
            else if (message.Text == "➕ Додавання рецепту")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть назву рецепту :");
                operation = "AddRecipe";
            }
            else if (message.Text == "❌ Видалити рецепт")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть назву рецепту, який бажаєте видалити :");
                operation = "DeleteRecipe";
            }
            else if (message.Text == "🔄 Оновити дані рецепту")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть назву рецепту, який бажаєте оновити :");
                operation = "UpdateRecipe";               
            }
            else if (message.Text == "Назад ↩️")
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new
                   (
                   new[]
                       {
                        new KeyboardButton[] { "🔍 Пошук страви 🔍" },
                        new KeyboardButton[] { "🍳📚 Моя кулінарна книга" },
                        new KeyboardButton[] { "🍽️🔥 Калорійність страви 🍽️🔥" }
                       }
                   )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Чим я можу вам допомогти?", replyMarkup: replyKeyboardMarkup);
                return;
            }
            else
            {
                if (operation == "EnterStartRecipe")
                {
                    MyRecipes.NameRecipe = message.Text;                  
                    SendRecipe(botClient,  message, MyRecipes.NameRecipe);
                }
                else if (operation == "EnterStartCaloriesRecipe")
                {
                    MyRecipes.NameRecipe = message.Text;                   
                    ProcessRecipesAsync(botClient, message, MyRecipes.NameRecipe);                  
                }
                else if (operation == "AddRecipe")
                {
                    MyRecipes.Id = message.Chat.Id;
                    MyRecipes.NameRecipe = message.Text;                    
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть рецепт :");
                    operation = "AddRecipeText";                    
                }
                else if (operation == "AddRecipeText")
                {                    
                    umessage.text = message.Text;
                    MyRecipes.Recipe = umessage.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    AddRecipe( message, MyRecipes.Id, MyRecipes.NameRecipe, MyRecipes.Recipe);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт створено! 🎉👨‍🍳");                 
                }
                else if (operation == "SearchRecipe")
                {
                    MyRecipes.Id = message.Chat.Id;
                    MyRecipes.NameRecipe = message.Text;
                    SearchRecipeByName(botClient,  message, MyRecipes.Id, MyRecipes.NameRecipe);                    
                }
                else if (operation == "DeleteRecipe")
                {
                    Database db = new Database();
                    MyRecipes.Id = message.Chat.Id;
                    MyRecipes.NameRecipe = message.Text;
                    MyRecipes recipe = await db.GetRecipeByIdAndNameAsync(MyRecipes.Id, MyRecipes.NameRecipe);
                    if (recipe != null)
                    {
                        DeleteRecipeByNameAndId( botClient,  message, MyRecipes.Id, MyRecipes.NameRecipe);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт не знайдено. 😔🚫");
                    }
                }
                else if(operation == "UpdateRecipe")
                {
                    Database db = new Database();
                    MyRecipes.Id = message.Chat.Id;
                    MyRecipes.NameRecipe = message.Text;
                    MyRecipes recipe = await db.GetRecipeByIdAndNameAsync(MyRecipes.Id, MyRecipes.NameRecipe);
                    if (recipe != null)
                    {
                        operation = "UpdateRecipeText";
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Введіть оновлений текст рецепту : ");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт не знайдено. 😔🚫");
                    }
                }
                else if (operation == "UpdateRecipeText")
                {
                    umessage.text = message.Text;
                    MyRecipes.Recipe = umessage.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);                  
                    UpdateRecipeByIdAndName(botClient, message, MyRecipes.Id, MyRecipes.NameRecipe, MyRecipes.Recipe);
                    operation = null;
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Error");
                }
            }
        }
        //recipe 
        private async Task SendRecipe(ITelegramBotClient botClient, Message message, string recipeName)
        {            
            var recipes = await ClientRecipe.GetRecipes(recipeName);

            if (recipes.Count > 0)
            {                
                var recipe = recipes[0];
            
                var mesage = $"Title: {recipe.Title}\n" +
                              $"Ingredients: {recipe.Ingredients}\n" +
                              $"Servings: {recipe.Servings}\n" +
                              $"Instructions: {recipe.Instructions}";

                await botClient.SendTextMessageAsync(message.Chat.Id, mesage);
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт не знайдено. 😔🚫");
            }
        }
        
        //nutrition
        private async Task ProcessRecipesAsync(ITelegramBotClient botClient, Message message, string recipeName)
        {
            var recipes = await NutritionClient.GetNutritions(recipeName);
            if (recipes.Count > 0)
            {               
                var recipe = recipes[0];
                
                var mesage = $"Name: {recipe.Name}\n" +
                              $"Calories: {recipe.Calories}\n" +
                              $"Serving_size_g: {recipe.Serving_size_g}\n" +
                              $"Fat_total_g: {recipe.Fat_total_g}";

                await botClient.SendTextMessageAsync(message.Chat.Id, mesage);
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт не знайдено. 😔🚫");
            }
        }
        
        //додавання рецепту
        private async Task AddRecipe(Message message, long Id, string NameRecipe, string[] Recipe)
        {
            Database db = new Database();            
            MyRecipes recipe1 = new MyRecipes { Id = Id, NameRecipe = NameRecipe, Recipe = Recipe };
            await db.InsertRecipeAsync(recipe1);
            //await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт додано!");      
        }
        
        //Пошук рецепту за NameRecipe and Id
        private async Task SearchRecipeByName(ITelegramBotClient botClient, Message message, long Id, string NameRecipe)
        {
            Database db = new Database();
            try
            {
                MyRecipes recipe = await db.GetRecipeByIdAndNameAsync(Id, NameRecipe);
                if (recipe != null)
                {
                    string recipeInfo = $"Рецепт знайдено! 📝🧑‍🍳\nНазва рецепту: {recipe.NameRecipe}\nРецепт: {string.Join(", ", recipe.Recipe)}";
                    await botClient.SendTextMessageAsync(message.Chat.Id, recipeInfo);
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт не знайдено. 😔🚫");
                }
            }
            catch (Exception ex)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Error: {ex.Message}");
            }
        }

        //Виведення назв рецептів за Id
        private async Task DisplayRecipes(ITelegramBotClient botClient, Message message, long Id)
        {           
            Database db = new Database();
            List<MyRecipes> recipes = await db.SelectRecipesAsync(Id);
            
            List<string> recipeNames = new List<string>();
            //Console.WriteLine(recipeNames.Count);
            if (recipes.Count != 0)
            {
                //await botClient.SendTextMessageAsync(message.Chat.Id, $"Список назв рецептів, які ви зберігали :");
                foreach (MyRecipes recipe in recipes)
                {
                    recipeNames.Add("☁️ " + recipe.NameRecipe);
                }
                await botClient.SendTextMessageAsync(message.Chat.Id,$"Ось список назв рецептів, які ви зберігали: 📋🧾 \n{string.Join("\n", recipeNames)}" );
            }
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Сумно казати, але ви не записали жодного рецепту у вашу кулінарну книгу😭💔");
            }


        }

        //Видалення рецепту за NameRecipe and Id
        private async Task DeleteRecipeByNameAndId(ITelegramBotClient botClient, Message message, long Id, string NameRecipe)
        {
            Database db = new Database();
            try
            {                
                await db.DeleteRecipeByNameAndIdAsync(Id, NameRecipe);
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Рецепт успішно видалено. ✅😊");          
            }
            catch (Exception ex)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Error: {ex.Message}");
            }
        }

        //Оновлення рецепта за NameRecipe and Id
        private async Task UpdateRecipeByIdAndName(ITelegramBotClient botClient, Message message, long Id, string NameRecipe, string[] Recipe)
        {
            Database db = new Database();
            MyRecipes updatedRecipe = new MyRecipes
            {
                Id = Id,
                NameRecipe = NameRecipe,
                Recipe = Recipe
            };
            try
            {               
                await db.UpdateRecipeByIdAndNameAsync(Id, NameRecipe, updatedRecipe);
                await botClient.SendTextMessageAsync(message.Chat.Id, "Рецепт успішно оновлено. ✨👩‍🍳");                
            }
            catch (Exception ex)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, $"Error: {ex.Message}");
            }
        }


    }

}







