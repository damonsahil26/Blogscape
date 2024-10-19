# Blogscape

.NET 8 MVC application for the Blogscape project. This application serves as a personal blogging platform where users can create, manage, and read articles. The project features simple file-based storage for articles and basic authentication for the admin section.

Project Task URL : [https://roadmap.sh/projects/blogscape](https://roadmap.sh/projects/personal-blog)

## Features

- **Blogs Management**: Create, read, and manage blog articles stored in the filesystem.
- **File-Based Storage**: Articles are saved as separate files in JSON format.
- **Basic Authentication**: Secure access to the admin section with simple username and password.
- **HTML and CSS Frontend**: Rendered pages using HTML and CSS for a clean and responsive design.

## Installation

To run this application, follow these steps:

1. Clone this repository:
    ```bash
    git clone https://github.com/damonsahil26/Blogscape.git
    ```

2. Navigate to the project directory:
    ```bash
    cd blogscape
    ```

3. Restore dependencies:
    ```bash
    dotnet restore
    ```

4. Start the application:
    ```bash
    dotnet run
    ```

5. Access the application at `http://localhost:5015/`.

## Usage

Once you run the application, you can navigate to the homepage to read the latest blog articles. To manage articles, you need to log in to the admin section.

### Admin Access

1. **Admin Login**: Navigate to `http://localhost:5015/Admin/ViewBlog` and enter the following credentials:
   - **Username**: admin
   - **Password**: password

2. **Article Management**: In the admin section, you can create, edit, or delete blog articles stored in the filesystem.

### Example Usage

```plaintext
Visit http://localhost:5015 to access the blog homepage.
Log in to the admin section at `http://localhost:5015/Admin/ViewBlog with:
Username: admin
Password: password
