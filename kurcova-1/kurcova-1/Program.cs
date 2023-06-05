
using Telegram.Bot.Types;
using Telegram.Bot;
using kurcova_1;
using kurcova_1.Models;
using kurcova_1.Clients;

// **** Виведення всіх рецептів ****

//var recipes = await ClientRecipe.GetRecipes("italian wedding soup");

//foreach (var recipe in recipes)
//{
//    Console.WriteLine("Title: " + recipe.Title);
//    Console.WriteLine("Ingredients: " + recipe.Ingredients);
//    Console.WriteLine("Servings: " + recipe.Servings);
//    Console.WriteLine("Instructions: " + recipe.Instructions);
//    Console.WriteLine();
//}


// *** Виводить перший рецепт з списку по запиту ***

//var recipes = await ClientRecipe.GetRecipes("italian wedding soup");
//if (recipes.Count > 0)
//{
//    Console.WriteLine("Title: " + recipes[0].Title);
//    Console.WriteLine("Ingredients: " + recipes[0].Ingredients);
//    Console.WriteLine("Servings: " + recipes[0].Servings);
//    Console.WriteLine("Instructions: " + recipes[0].Instructions);
//}
//else
//{
//    Console.WriteLine("No recipes found.");
//}

// **** Підключаємося до бази даних ****

Database db = new Database();

// **** Видалення всіх даних з бази даних ****

//await db.DeleteAllRecipesAsync();
//Console.WriteLine("Всі рецепти видалені з бази даних.");

// **** Видалення рецепту за назвою **** потребує поля recipeName

//await db.DeleteRecipeByNameAsync(recipeName);
//Console.WriteLine($"Рецепт з назвою {recipeName} був успішно видалений.");


// **** Виведення одного рецепту за назвою ****

//Console.WriteLine("Введіть назву рецепту для виведення:");
//string recipeName = Console.ReadLine();
//MyRecipes selectedRecipe = await db.GetRecipeByNameAsync(recipeName);
//if (selectedRecipe != null)
//{
//    Console.WriteLine($"Назва рецепту: {selectedRecipe.NameRecipe}, Час: {selectedRecipe.Time}, Кроки рецепту: {string.Join(", ", selectedRecipe.Recipe)}");
//}
//else
//{
//    Console.WriteLine("Рецепт з такою назвою не знайдено.");
//}

// **** Додавання рецепту в базу данних ****

//Console.WriteLine("Введіть рецепт (натисніть Enter після кожного рядка, введіть пустий рядок для завершення):");
//string NameRecipe = Console.ReadLine();
//List<string> recipeLines = new List<string>();
//string line;
//while (!string.IsNullOrEmpty(line = Console.ReadLine()))
//{
//    recipeLines.Add(line);
//}

//string[] recipeArray = recipeLines.ToArray();

//// Вставка даних рецепту в базу даних
//MyRecipes recipe1 = new MyRecipes { Id = 1, NameRecipe = NameRecipe, Recipe = recipeArray };
//await db.InsertRecipeAsync(recipe1);


//**** Зчитування даних рецептів з бази даних ****

//List<MyRecipes> recipesi = await db.SelectRecipesAsync();
//Console.WriteLine("Список рецептів:");

//foreach (MyRecipes recipe in recipesi)
//{
//    Console.WriteLine($"Id: {recipe.Id}, Назва рецепту: {recipe.NameRecipe}");
//    Console.WriteLine("Рецепт:");
//    foreach (string lin in recipe.Recipe)
//    {
//        Console.WriteLine(lin);
//    }
//    Console.WriteLine($"Час : {recipe.Time} \n");

//}

//**** оновлення рецепту ****

//try
//{
//    Database database = new Database();

//    //Назву рецепту, який оновлюємо
//    Console.WriteLine("Enter the name of the recipe to update:");
//    string recipeName = Console.ReadLine();

//    // Перевірка
//    MyRecipes existingRecipe = await database.GetRecipeByNameAsync(recipeName);
//    if (existingRecipe == null)
//    {
//        Console.WriteLine("Recipe not found.");
//        return;
//    }

//    // Поточні значення рецепту
//    Console.WriteLine("Current Recipe Details:");
//    Console.WriteLine($"Id: {existingRecipe.Id}");
//    Console.WriteLine($"Name: {existingRecipe.NameRecipe}");
//    Console.WriteLine("Recipe Steps:");
//    foreach (var step in existingRecipe.Recipe)
//    {
//        Console.WriteLine(step);
//    }
//    Console.WriteLine($"Time: {existingRecipe.Time}");

//    // Оновити значення рецепту
//    MyRecipes updatedRecipe = new MyRecipes
//    {
//        Id = existingRecipe.Id,
//        NameRecipe = existingRecipe.NameRecipe,
//        Recipe = existingRecipe.Recipe,
//        Time = DateTime.Now
//    };

//    Console.WriteLine("Enter the updated recipe:");
//    updatedRecipe.Recipe = Console.ReadLine().Split('\n');

//    //Метод оновлення рецепту
//    await database.UpdateRecipeByNameAsync(recipeName, updatedRecipe);

//    Console.WriteLine("Recipe updated successfully.");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"An error occurred: {ex.Message}");
//}


// **** nutrition ****

//var recipes = await NutritionClient.GetNutritions("italian wedding soup");
//if (recipes.Count > 0)
//{
//    Console.WriteLine("Name: " + recipes[0].Name);
//    Console.WriteLine("Calories: " + recipes[0].Calories);
//    Console.WriteLine("Serving_size_g: " + recipes[0].Serving_size_g);
//    Console.WriteLine("Fat_total_g: " + recipes[0].Fat_total_g);
//}
//else
//{
//    Console.WriteLine("No recipes found.");
//}

//DatabaseUser user = new DatabaseUser();

//user.DeleteAllRecipesAsync().Wait();

//Console.WriteLine("OK");t

Mybot mybot = new Mybot();
try
{
    mybot.Start();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}




//// Підключення до бази даних
////var connectionString = "YOUR_POSTGRESQL_CONNECTION_STRING";
//DatabaseUser dbu = new DatabaseUser();

//// Генерація унікального ідентифікатора
//string uniqueId = await dbu.GenerateUniqueUserIdAsync();

//// Перевірка наявності користувача в базі даних
//bool userExists = await dbu.CheckUserIdExistsAsync(uniqueId);
////Users users = new Users
////{
////    Id = 50212,
////    User = "dianaharmony"
////};
////await dbu.InsertRecipeAsync(users);
//if (!userExists)
//{
//    // Отримання псевдоніму користувача
//    string username = "example_username"; // Замініть на реальне ім'я користувача

//    // Запис користувача в базу даних
//    await dbu.InsertRecipeAsync(user);
//}

//Console.WriteLine("User data processed.");
Console.ReadKey();