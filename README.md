 <img height="160em" src="https://conteudo.precocerto.co/wp-content/uploads/2015/05/roquecontente.png">

# Like Feature
   Like button feature: 
  - Easily added to an article.
  - Use cases:
    - When a user visits an article, a like button is rendered and displays the total number of likes
    - When a user clicks the like button, the count increments by one.

## Stack
 ![C#](https://img.shields.io/badge/-Csharp-333333?style=flat&logo=C%2B%2B&logoColor=00599C)
  : Razor Pages with Entity Framework on ASP.NET

## How to run in your machine
- Clone the repo
- Install dependencies with Nuget
- Open with the navegator the `Views/Likes/Index` Page

## How to Use
-`url/Likes/Index`: list of created articles and some related info;
- `url/Likes/Article/{id}`: Article; 
- `/Likes/Create`: Creates a new article with a form
    - `like_user`: `Requested: False` it's allowed to create an article anonymously
- `Like Button`: when it's clicked, the count increments by one and it's shows the total number os likes.
