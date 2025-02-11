using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessModel.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    CookTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloriesPerServing = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "Rating", "Status", "UserName" },
                values: new object[] { 1, new DateTime(2025, 2, 11, 14, 44, 23, 417, DateTimeKind.Local).AddTicks(3902), 6.8f, 0, "John Doe" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CaloriesPerServing", "CookTimeMinutes", "Cuisine", "Difficulty", "ImageUrl", "Ingredients", "Instructions", "MealType", "Name", "PrepTimeMinutes", "Rating", "ReviewCount", "Servings", "Tags", "UserId" },
                values: new object[,]
                {
                    { 1, 300, 15, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/1.webp", "Pizza dough\nTomato sauce\nFresh mozzarella cheese\nFresh basil leaves\nOlive oil\nSalt and pepper to taste", "Preheat the oven to 475°F (245°C).\nRoll out the pizza dough and spread tomato sauce evenly.\nTop with slices of fresh mozzarella and fresh basil leaves.\nDrizzle with olive oil and season with salt and pepper.\nBake in the preheated oven for 12-15 minutes or until the crust is golden brown.\nSlice and serve hot.", "[\"Dinner\"]", "Classic Margherita Pizza", 20, 4.6f, 98, 4, "Pizza\nItalian", 166 },
                    { 2, 250, 20, "Asian", 1, "https://cdn.dummyjson.com/recipe-images/2.webp", "Tofu, cubed\nBroccoli florets\nCarrots, sliced\nBell peppers, sliced\nSoy sauce\nGinger, minced\nGarlic, minced\nSesame oil\nCooked rice for serving", "In a wok, heat sesame oil over medium-high heat.\nAdd minced ginger and garlic, sauté until fragrant.\nAdd cubed tofu and stir-fry until golden brown.\nAdd broccoli, carrots, and bell peppers. Cook until vegetables are tender-crisp.\nPour soy sauce over the stir-fry and toss to combine.\nServe over cooked rice.", "[\"Lunch\"]", "Vegetarian Stir-Fry", 15, 4.7f, 26, 3, "Vegetarian\nStir-fry\nAsian", 143 },
                    { 3, 150, 10, "American", 0, "https://cdn.dummyjson.com/recipe-images/3.webp", "All-purpose flour\nButter, softened\nBrown sugar\nWhite sugar\nEggs\nVanilla extract\nBaking soda\nSalt\nChocolate chips", "Preheat the oven to 350°F (175°C).\nIn a bowl, cream together softened butter, brown sugar, and white sugar.\nBeat in eggs one at a time, then stir in vanilla extract.\nCombine flour, baking soda, and salt. Gradually add to the wet ingredients.\nFold in chocolate chips.\nDrop rounded tablespoons of dough onto ungreased baking sheets.\nBake for 10-12 minutes or until edges are golden brown.\nAllow cookies to cool on the baking sheet for a few minutes before transferring to a wire rack.", "[\"Snack\",\"Dessert\"]", "Chocolate Chip Cookies", 15, 4.9f, 13, 24, "Cookies\nDessert\nBaking", 34 },
                    { 4, 500, 20, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/4.webp", "Fettuccine pasta\nChicken breast, sliced\nHeavy cream\nParmesan cheese, grated\nGarlic, minced\nButter\nSalt and pepper to taste\nFresh parsley for garnish", "Cook fettuccine pasta according to package instructions.\nIn a pan, sauté sliced chicken in butter until fully cooked.\nAdd minced garlic and cook until fragrant.\nPour in heavy cream and grated Parmesan cheese. Stir until the cheese is melted.\nSeason with salt and pepper to taste.\nCombine the Alfredo sauce with cooked pasta.\nGarnish with fresh parsley before serving.", "[\"Lunch\",\"Dinner\"]", "Chicken Alfredo Pasta", 15, 4.9f, 82, 4, "Pasta\nChicken", 136 },
                    { 5, 380, 25, "Mexican", 0, "https://cdn.dummyjson.com/recipe-images/5.webp", "Chicken thighs\nMango, diced\nRed onion, finely chopped\nCilantro, chopped\nLime juice\nJalapeño, minced\nSalt and pepper to taste\nCooked rice for serving", "Season chicken thighs with salt and pepper.\nGrill or bake chicken until fully cooked.\nIn a bowl, combine diced mango, chopped red onion, cilantro, minced jalapeño, and lime juice.\nDice the cooked chicken and mix it with the mango salsa.\nServe over cooked rice.", "[\"Dinner\"]", "Mango Salsa Chicken", 15, 4.9f, 63, 3, "Chicken\nSalsa", 26 },
                    { 6, 280, 15, "Mediterranean", 0, "https://cdn.dummyjson.com/recipe-images/6.webp", "Quinoa, cooked\nAvocado, diced\nCherry tomatoes, halved\nCucumber, diced\nRed bell pepper, diced\nFeta cheese, crumbled\nLemon vinaigrette dressing\nSalt and pepper to taste", "In a large bowl, combine cooked quinoa, diced avocado, halved cherry tomatoes, diced cucumber, diced red bell pepper, and crumbled feta cheese.\nDrizzle with lemon vinaigrette dressing and toss to combine.\nSeason with salt and pepper to taste.\nChill in the refrigerator before serving.", "[\"Lunch\",\"Side Dish\"]", "Quinoa Salad with Avocado", 20, 4.4f, 59, 4, "Salad\nQuinoa", 197 },
                    { 7, 120, 10, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/7.webp", "Baguette, sliced\nTomatoes, diced\nFresh basil, chopped\nGarlic cloves, minced\nBalsamic glaze\nOlive oil\nSalt and pepper to taste", "Preheat the oven to 375°F (190°C).\nPlace baguette slices on a baking sheet and toast in the oven until golden brown.\nIn a bowl, combine diced tomatoes, chopped fresh basil, minced garlic, and a drizzle of olive oil.\nSeason with salt and pepper to taste.\nTop each toasted baguette slice with the tomato-basil mixture.\nDrizzle with balsamic glaze before serving.", "[\"Appetizer\"]", "Tomato Basil Bruschetta", 15, 4.7f, 95, 6, "Bruschetta\nItalian", 137 },
                    { 8, 380, 15, "Asian", 1, "https://cdn.dummyjson.com/recipe-images/8.webp", "Beef sirloin, thinly sliced\nBroccoli florets\nSoy sauce\nOyster sauce\nSesame oil\nGarlic, minced\nGinger, minced\nCornstarch\nCooked white rice for serving", "In a bowl, mix soy sauce, oyster sauce, sesame oil, and cornstarch to create the sauce.\nIn a wok, stir-fry thinly sliced beef until browned. Remove from the wok.\nStir-fry broccoli florets, minced garlic, and minced ginger in the same wok.\nAdd the cooked beef back to the wok and pour the sauce over the mixture.\nStir until everything is coated and heated through.\nServe over cooked white rice.", "[\"Dinner\"]", "Beef and Broccoli Stir-Fry", 20, 4.7f, 58, 4, "Beef\nStir-fry\nAsian", 18 },
                    { 9, 200, 0, "Italian", 0, "https://cdn.dummyjson.com/recipe-images/9.webp", "Tomatoes, sliced\nFresh mozzarella cheese, sliced\nFresh basil leaves\nBalsamic glaze\nExtra virgin olive oil\nSalt and pepper to taste", "Arrange alternating slices of tomatoes and fresh mozzarella on a serving platter.\nTuck fresh basil leaves between the slices.\nDrizzle with balsamic glaze and extra virgin olive oil.\nSeason with salt and pepper to taste.\nServe immediately as a refreshing salad.", "[\"Lunch\"]", "Caprese Salad", 10, 4.6f, 82, 2, "Salad\nCaprese", 128 },
                    { 10, 400, 20, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/10.webp", "Linguine pasta\nShrimp, peeled and deveined\nGarlic, minced\nWhite wine\nLemon juice\nRed pepper flakes\nFresh parsley, chopped\nSalt and pepper to taste", "Cook linguine pasta according to package instructions.\nIn a skillet, sauté minced garlic in olive oil until fragrant.\nAdd shrimp and cook until pink and opaque.\nPour in white wine and lemon juice. Simmer until the sauce slightly thickens.\nSeason with red pepper flakes, salt, and pepper.\nToss cooked linguine in the shrimp scampi sauce.\nGarnish with chopped fresh parsley before serving.", "[\"Dinner\"]", "Shrimp Scampi Pasta", 15, 4.3f, 5, 3, "Pasta\nShrimp", 114 },
                    { 11, 550, 45, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/11.webp", "Basmati rice\nChicken, cut into pieces\nOnions, thinly sliced\nTomatoes, chopped\nYogurt\nGinger-garlic paste\nBiryani masala\nGreen chilies, sliced\nFresh coriander leaves\nMint leaves\nGhee\nSalt to taste", "Marinate chicken with yogurt, ginger-garlic paste, biryani masala, and salt.\nIn a pot, sauté sliced onions until golden brown. Remove half for later use.\nLayer marinated chicken, chopped tomatoes, half of the fried onions, and rice in the pot.\nTop with ghee, green chilies, fresh coriander leaves, mint leaves, and the remaining fried onions.\nCover and cook on low heat until the rice is fully cooked and aromatic.\nServe hot, garnished with additional coriander and mint leaves.", "[\"Lunch\",\"Dinner\"]", "Chicken Biryani", 30, 5f, 32, 6, "Biryani\nChicken\nMain course\nIndian\nPakistani\nAsian", 133 },
                    { 12, 420, 30, "Pakistani", 0, "https://cdn.dummyjson.com/recipe-images/12.webp", "Chicken, cut into pieces\nTomatoes, chopped\nGreen chilies, sliced\nGinger, julienned\nGarlic, minced\nCoriander powder\nCumin powder\nRed chili powder\nGaram masala\nCooking oil\nFresh coriander leaves\nSalt to taste", "In a wok (karahi), heat cooking oil and sauté minced garlic until golden brown.\nAdd chicken pieces and cook until browned on all sides.\nAdd chopped tomatoes, green chilies, ginger, and spices. Cook until tomatoes are soft.\nCover and simmer until the chicken is tender and the oil separates from the masala.\nGarnish with fresh coriander leaves and serve hot with naan or rice.", "[\"Lunch\",\"Dinner\"]", "Chicken Karahi", 20, 4.8f, 68, 4, "Chicken\nKarahi\nMain course\nIndian\nPakistani\nAsian", 49 },
                    { 13, 380, 35, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/13.webp", "Ground beef\nPotatoes, peeled and diced\nOnions, finely chopped\nTomatoes, chopped\nGinger-garlic paste\nCumin powder\nCoriander powder\nTurmeric powder\nRed chili powder\nCooking oil\nFresh coriander leaves\nSalt to taste", "In a pan, heat cooking oil and sauté chopped onions until golden brown.\nAdd ginger-garlic paste and sauté until fragrant.\nAdd ground beef and cook until browned. Drain excess oil if needed.\nAdd diced potatoes, chopped tomatoes, and spices. Mix well.\nCover and simmer until the potatoes are tender and the masala is well-cooked.\nGarnish with fresh coriander leaves and serve hot with naan or rice.", "[\"Lunch\",\"Dinner\"]", "Aloo Keema", 25, 4.6f, 53, 5, "Keema\nPotatoes\nMain course\nPakistani\nAsian", 152 },
                    { 14, 320, 20, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/14.webp", "Ground beef\nOnions, finely chopped\nTomatoes, finely chopped\nGreen chilies, chopped\nCoriander leaves, chopped\nPomegranate seeds\nGinger-garlic paste\nCumin powder\nCoriander powder\nRed chili powder\nEgg\nCooking oil\nSalt to taste", "In a large bowl, mix ground beef, chopped onions, tomatoes, green chilies, coriander leaves, and pomegranate seeds.\nAdd ginger-garlic paste, cumin powder, coriander powder, red chili powder, and salt. Mix well.\nAdd an egg to bind the mixture and form into round flat kebabs.\nHeat cooking oil in a pan and shallow fry the kebabs until browned on both sides.\nServe hot with naan or mint chutney.", "[\"Lunch\",\"Dinner\",\"Snacks\"]", "Chapli Kebabs", 30, 4.7f, 98, 4, "Kebabs\nBeef\nIndian\nPakistani\nAsian", 152 },
                    { 15, 280, 30, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/15.webp", "Mustard greens, washed and chopped\nSpinach, washed and chopped\nCornmeal (makki ka atta)\nOnions, finely chopped\nGreen chilies, chopped\nGinger, grated\nGhee\nSalt to taste", "Boil mustard greens and spinach until tender. Drain and blend into a coarse paste.\nIn a pan, sauté chopped onions, green chilies, and grated ginger in ghee until golden brown.\nAdd the greens paste and cook until it thickens.\nMeanwhile, knead cornmeal with water to make a dough. Roll into rotis (flatbreads).\nCook the rotis on a griddle until golden brown.\nServe hot saag with makki di roti and a dollop of ghee.", "[\"Breakfast\",\"Lunch\",\"Dinner\"]", "Saag (Spinach) with Makki di Roti", 40, 4.3f, 86, 3, "Saag\nRoti\nMain course\nIndian\nPakistani\nAsian", 43 },
                    { 16, 480, 25, "Japanese", 1, "https://cdn.dummyjson.com/recipe-images/16.webp", "Ramen noodles\nChicken broth\nSoy sauce\nMirin\nSesame oil\nShiitake mushrooms, sliced\nBok choy, chopped\nGreen onions, sliced\nSoft-boiled eggs\nGrilled chicken slices\nNorwegian seaweed (nori)", "Cook ramen noodles according to package instructions and set aside.\nIn a pot, combine chicken broth, soy sauce, mirin, and sesame oil. Bring to a simmer.\nAdd sliced shiitake mushrooms and chopped bok choy. Cook until vegetables are tender.\nDivide the cooked noodles into serving bowls and ladle the hot broth over them.\nTop with green onions, soft-boiled eggs, grilled chicken slices, and nori.\nServe hot and enjoy the authentic Japanese ramen!", "[\"Dinner\"]", "Japanese Ramen Soup", 20, 4.9f, 38, 2, "Ramen\nJapanese\nSoup\nAsian", 85 },
                    { 17, 320, 30, "Moroccan", 0, "https://cdn.dummyjson.com/recipe-images/17.webp", "Chickpeas, cooked\nTomatoes, chopped\nCarrots, diced\nOnions, finely chopped\nGarlic, minced\nCumin\nCoriander\nCinnamon\nPaprika\nVegetable broth\nOlives\nFresh cilantro, chopped", "In a tagine or large pot, sauté chopped onions and minced garlic until softened.\nAdd diced carrots, chopped tomatoes, and cooked chickpeas.\nSeason with cumin, coriander, cinnamon, and paprika. Stir to coat.\nPour in vegetable broth and bring to a simmer. Cook until carrots are tender.\nStir in olives and garnish with fresh cilantro before serving.\nServe this flavorful Moroccan dish with couscous or crusty bread.", "[\"Dinner\"]", "Moroccan Chickpea Tagine", 15, 4.5f, 50, 4, "Tagine\nChickpea\nMoroccan", 207 },
                    { 18, 550, 20, "Korean", 1, "https://cdn.dummyjson.com/recipe-images/18.webp", "Cooked white rice\nBeef bulgogi (marinated and grilled beef slices)\nCarrots, julienned and sautéed\nSpinach, blanched and seasoned\nZucchini, sliced and grilled\nBean sprouts, blanched\nFried egg\nGochujang (Korean red pepper paste)\nSesame oil\nToasted sesame seeds", "Arrange cooked white rice in a bowl.\nTop with beef bulgogi, sautéed carrots, seasoned spinach, grilled zucchini, and blanched bean sprouts.\nPlace a fried egg on top and drizzle with gochujang and sesame oil.\nSprinkle with toasted sesame seeds before serving.\nMix everything together before enjoying this delicious Korean bibimbap!\nFeel free to customize with additional vegetables or protein.", "[\"Dinner\"]", "Korean Bibimbap", 30, 4.9f, 56, 2, "Bibimbap\nKorean\nRice", 121 },
                    { 19, 420, 45, "Greek", 1, "https://cdn.dummyjson.com/recipe-images/19.webp", "Eggplants, sliced\nGround lamb or beef\nOnions, finely chopped\nGarlic, minced\nTomatoes, crushed\nRed wine\nCinnamon\nAllspice\nNutmeg\nOlive oil\nMilk\nFlour\nParmesan cheese\nEgg yolks", "Preheat oven to 375°F (190°C).\nSauté sliced eggplants in olive oil until browned. Set aside.\nIn the same pan, cook chopped onions and minced garlic until softened.\nAdd ground lamb or beef and brown. Stir in crushed tomatoes, red wine, and spices.\nIn a separate saucepan, make béchamel sauce: melt butter, whisk in flour, add milk, and cook until thickened.\nRemove from heat and stir in Parmesan cheese and egg yolks.\nIn a baking dish, layer eggplants and meat mixture. Top with béchamel sauce.\nBake for 40-45 minutes until golden brown. Let it cool before slicing.\nServe slices of moussaka warm and enjoy this Greek classic!", "[\"Dinner\"]", "Greek Moussaka", 45, 4.3f, 26, 6, "Moussaka\nGreek", 173 },
                    { 20, 480, 25, "Pakistani", 1, "https://cdn.dummyjson.com/recipe-images/20.webp", "Chicken thighs, boneless and skinless\nYogurt\nGinger-garlic paste\nGaram masala\nKashmiri red chili powder\nTomato puree\nButter\nHeavy cream\nKasuri methi (dried fenugreek leaves)\nSugar\nSalt to taste", "Marinate chicken thighs in a mixture of yogurt, ginger-garlic paste, garam masala, and Kashmiri red chili powder.\nIn a pan, melt butter and sauté the marinated chicken until browned.\nAdd tomato puree and cook until the oil separates. Stir in heavy cream.\nSprinkle kasuri methi, sugar, and salt. Simmer until the chicken is fully cooked.\nServe this creamy butter chicken over rice or with naan for an authentic Pakistani/Indian experience.", "[\"Dinner\"]", "Butter Chicken (Murgh Makhani)", 30, 4.5f, 44, 4, "Butter chicken\nCurry\nIndian\nPakistani\nAsian", 138 },
                    { 21, 480, 30, "Thai", 1, "https://cdn.dummyjson.com/recipe-images/21.webp", "Chicken thighs, boneless and skinless\nGreen curry paste\nCoconut milk\nFish sauce\nSugar\nEggplant, sliced\nBell peppers, sliced\nBasil leaves\nJasmine rice for serving", "In a pot, simmer green curry paste in coconut milk.\nAdd chicken, fish sauce, and sugar. Cook until chicken is tender.\nStir in sliced eggplant and bell peppers. Simmer until vegetables are cooked.\nGarnish with fresh basil leaves.\nServe hot over jasmine rice and enjoy this Thai classic!", "[\"Dinner\"]", "Thai Green Curry", 20, 4.2f, 18, 4, "Curry\nThai", 153 },
                    { 22, 180, 0, "Indian", 0, "https://cdn.dummyjson.com/recipe-images/22.webp", "Ripe mango, peeled and diced\nYogurt\nMilk\nHoney\nCardamom powder\nIce cubes", "In a blender, combine diced mango, yogurt, milk, honey, and cardamom powder.\nBlend until smooth and creamy.\nAdd ice cubes and blend again until the lassi is chilled.\nPour into glasses and garnish with a sprinkle of cardamom.\nEnjoy this refreshing Mango Lassi!", "[\"Beverage\"]", "Mango Lassi", 10, 4.7f, 15, 2, "Lassi\nMango\nIndian\nPakistani\nAsian", 76 },
                    { 23, 350, 0, "Italian", 1, "https://cdn.dummyjson.com/recipe-images/23.webp", "Espresso, brewed and cooled\nLadyfinger cookies\nMascarpone cheese\nHeavy cream\nSugar\nCocoa powder", "In a bowl, whip heavy cream until stiff peaks form.\nIn another bowl, mix mascarpone cheese and sugar until smooth.\nGently fold the whipped cream into the mascarpone mixture.\nDip ladyfinger cookies into brewed espresso and layer them in a serving dish.\nSpread a layer of the mascarpone mixture over the cookies.\nRepeat layers and finish with a dusting of cocoa powder.\nChill in the refrigerator for a few hours before serving.\nIndulge in the decadence of this classic Italian Tiramisu!", "[\"Dessert\"]", "Italian Tiramisu", 30, 4.6f, 0, 6, "Tiramisu\nItalian", 130 },
                    { 24, 280, 15, "Turkish", 0, "https://cdn.dummyjson.com/recipe-images/24.webp", "Ground lamb or beef\nOnions, grated\nGarlic, minced\nParsley, finely chopped\nCumin\nCoriander\nRed pepper flakes\nSalt and pepper to taste\nFlatbread for serving\nTahini sauce", "In a bowl, mix ground meat, grated onions, minced garlic, chopped parsley, and spices.\nForm the mixture into kebab shapes and grill until fully cooked.\nServe the kebabs on flatbread with a drizzle of tahini sauce.\nEnjoy these flavorful Turkish Kebabs with your favorite sides.", "[\"Dinner\"]", "Turkish Kebabs", 25, 4.6f, 78, 4, "Kebabs\nTurkish\nGrilling", 26 },
                    { 25, 220, 0, "Smoothie", 0, "https://cdn.dummyjson.com/recipe-images/25.webp", "Blueberries, fresh or frozen\nBanana, peeled and sliced\nGreek yogurt\nAlmond milk\nHoney\nChia seeds (optional)", "In a blender, combine blueberries, banana, Greek yogurt, almond milk, and honey.\nBlend until smooth and creamy.\nAdd chia seeds for extra nutrition and blend briefly.\nPour into a glass and enjoy this nutritious Blueberry Banana Smoothie!", "[\"Breakfast\",\"Beverage\"]", "Blueberry Banana Smoothie", 10, 4.8f, 30, 1, "Smoothie\nBlueberry\nBanana", 16 },
                    { 26, 180, 15, "Mexican", 0, "https://cdn.dummyjson.com/recipe-images/26.webp", "Corn on the cob\nMayonnaise\nCotija cheese, crumbled\nChili powder\nLime wedges", "Grill or roast corn on the cob until kernels are charred.\nBrush each cob with mayonnaise, then sprinkle with crumbled Cotija cheese and chili powder.\nServe with lime wedges for squeezing over the top.\nEnjoy this delicious and flavorful Mexican Street Corn!", "[\"Snack\",\"Side Dish\"]", "Mexican Street Corn (Elote)", 15, 4.6f, 2, 4, "Elote\nMexican\nStreet food", 93 },
                    { 27, 220, 40, "Russian", 1, "https://cdn.dummyjson.com/recipe-images/27.webp", "Beets, peeled and shredded\nCabbage, shredded\nPotatoes, diced\nOnions, finely chopped\nCarrots, grated\nTomato paste\nBeef or vegetable broth\nGarlic, minced\nBay leaves\nSour cream for serving", "In a pot, sauté chopped onions and garlic until softened.\nAdd shredded beets, cabbage, diced potatoes, grated carrots, and tomato paste.\nPour in broth and add bay leaves. Simmer until vegetables are tender.\nServe hot with a dollop of sour cream on top.\nEnjoy the hearty and comforting flavors of Russian Borscht!", "[\"Dinner\"]", "Russian Borscht", 30, 4.3f, 39, 6, "Borscht\nRussian\nSoup", 1 },
                    { 28, 320, 20, "Indian", 1, "https://cdn.dummyjson.com/recipe-images/28.webp", "Dosa batter (fermented rice and urad dal batter)\nPotatoes, boiled and mashed\nOnions, finely chopped\nMustard seeds\nCumin seeds\nCurry leaves\nTurmeric powder\nGreen chilies, chopped\nGhee\nCoconut chutney for serving", "In a pan, heat ghee and add mustard seeds, cumin seeds, and curry leaves.\nAdd chopped onions, green chilies, and turmeric powder. Sauté until onions are golden brown.\nMix in boiled and mashed potatoes. Cook until well combined and seasoned.\nSpread dosa batter on a hot griddle to make thin pancakes.\nPlace a spoonful of the potato mixture in the center, fold, and serve hot.\nPair with coconut chutney for a delicious South Indian meal.", "[\"Breakfast\"]", "South Indian Masala Dosa", 40, 4.4f, 96, 4, "Dosa\nIndian\nAsian", 138 },
                    { 29, 400, 10, "Lebanese", 0, "https://cdn.dummyjson.com/recipe-images/29.webp", "Falafel balls\nWhole wheat or regular wraps\nTomatoes, diced\nCucumbers, sliced\nRed onions, thinly sliced\nLettuce, shredded\nTahini sauce\nFresh parsley, chopped", "Warm falafel balls according to package instructions.\nPlace a generous serving of falafel in the center of each wrap.\nTop with diced tomatoes, sliced cucumbers, red onions, shredded lettuce, and fresh parsley.\nDrizzle with tahini sauce and wrap tightly.\nEnjoy this Lebanese Falafel Wrap filled with fresh and flavorful ingredients!", "[\"Lunch\"]", "Lebanese Falafel Wrap", 15, 4.7f, 84, 2, "Falafel\nLebanese\nWrap", 110 },
                    { 30, 150, 0, "Brazilian", 0, "https://cdn.dummyjson.com/recipe-images/30.webp", "Cachaça (Brazilian sugarcane spirit)\nLime, cut into wedges\nGranulated sugar\nIce cubes", "In a glass, muddle lime wedges with granulated sugar to release the juice.\nFill the glass with ice cubes.\nPour cachaça over the ice and stir well.\nSip and enjoy the refreshing taste of the Brazilian Caipirinha!\nAdjust sugar and lime to suit your taste preferences.", "[\"Beverage\"]", "Brazilian Caipirinha", 5, 4.4f, 55, 1, "Caipirinha\nBrazilian\nCocktail", 134 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "Quantity", "Rating", "RecipeId" },
                values: new object[,]
                {
                    { 1, 1, 2, 5f, 1 },
                    { 2, 1, 1, 8.2f, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_RecipeId",
                table: "OrderItems",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
