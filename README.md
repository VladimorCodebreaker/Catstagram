# 😸 Catstagram

Catstagram is a simple web application that allows users to share photos + comments about cats. The application has been developed using C#, ASP.NET, EntityFramework, Bootstrap, HTML, CSS, JS, JQuery.

---
## 🌱 Features

🍋 <strong>Registration and Login</strong>: Users can register and login to the application. The user's password is stored as a hashed value in the database.

🍋 <strong>Add New Cat Post</strong>: Users can add a new post by uploading an image (2MB max), adding their name, email, and comment (hashtags can be added). Form validation is implemented to ensure data integrity.

🍋 <strong>Catstagram Wall</strong>: Users can see a list of all available cat posts, sorted by date in descending order. Every post in the list contains all attributes, including the author name, comment, and date added, except the email, as it is dangerous / useless to disclose it.

🍋 <strong>Post Details</strong>: Users can view details of a specific post by clicking on the "Show Details" button in the Catstagram Wall. The details page displays all attributes of the post, except the email, as it is dangerous / useless to disclose it.

🍋 <strong>Edit Post</strong>: Admin / User can edit any post. The edit feature allows modifying the post's attributes except the post's ID and date added. Only authenticated users can perform the edit operation.

🍋 <strong>Delete Post</strong>: Admin can delete any post. The delete feature allows removing a post from the database. Only authenticated users can perform the delete operation.

🍋 <strong>Filter Posts</strong>: Users can search for posts by their hashtags / name using the search bar. The search feature filters the posts that have the searched hashtag or name.

🍋 <strong>Hashtag Filter</strong>: Hashtags from post comments are converted into links. When a link is clicked, a new page is displayed where posts having that hashtag are filtered.

🍋 <strong>Database Seeder</strong>: Seed data is generated in the database. The seeder feature allows populating the database with test data.

## 🍃 Getting Started

🍇 Clone the repository or download the zip file and extract it.<br>
🍇 Open the solution file Catstagram.sln in Visual Studio (2019 or later).<br>
🍇 Open the Package Manager Console and run the following command to create the database: `Update-Database`<br>
🍇 Run the application.<br>

## 🥥 Usage

🍙 Register and Login to the application. (Don't worry, you can always logout + your data is safe) <3<br>
🍙 Click on "Add New Cat Post" to add a new post.<br>
🍙 Click on "Catstagram Wall" to view all available cat posts.<br>
🍙 Click on the button "Show Details" in the Catstagram Wall to view its details.<br>
🍙 Click on "Edit" to edit a post.<br>
🍙 Click on "Delete" to delete a post.<br>
🍙 Use the search bar to search for posts by their hashtags / name.<br>
🍙 Click on a hashtag in a post comment to view all posts containing that hashtag.<br>
🍙 Give a Like ❤️ :)<br>
🍙 (Admin Only) you can see all the registered users, from the dropdown menu.<br>
🍙 View the Privacy Policy<br>

## 🍐 Credentials

The credentials for the admin are:<br>

<strong>Email:</strong>     admin@gmail.com<br>
<strong>Password:</strong>  Coding@1234?<br>

`PS: I don't allow more than one "admin". If you register you will automatically be a "user". Cheers.`

## 🍎 T.L.D.R

🍊 <strong>Common operations</strong>: Create, Delete, Details, Display, Edit, Search, Filter<br>
🍊 <strong>Account operations</strong>: Register, Login, Logout

## 🍣 Credits

This project was created by [Vladimir Wolfgang Schmadlak] for [Web Programming (Assignment)].

