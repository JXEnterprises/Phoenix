# Phoenix

The used truck deal system for appraisals, offers, and more!

## About

Here at JX Enterprises, we pride ourselves on our commitment to our customers. When you bring your truck to our award-winning dealerships for an appraisal, we aim to provide the fairest possible price. We base our pricing on a thorough inspection, backed by industry-leading data analysis from partners such as [National Inspection Services](https://www.nationalinspect.com/). All this means that you can be confident that the offer we provide represents a fair and accurate valuation of your truck.

## Getting Started

To get started with building this system from source on Windows, follow these steps:

1. Install [.NET Core 2.1](https://download.microsoft.com/download/D/0/4/D04C5489-278D-4C11-9BD3-6128472A7626/dotnet-sdk-2.1.301-win-gs-x64.exe).
2. Install [Visual Studio Code](https://code.visualstudio.com/).
3. Install [Git for Windows](https://git-scm.com/download/win) (download begins automatically).
4. Install a [SQL Server](https://go.microsoft.com/fwlink/?linkid=853016) instance, and ensure it uses Windows (integrated) authentication instead of SQL Authentication. Keep the default name so you can connect to it as `(local)`.
5. Choose a directory where you will work. The author keeps his source code in `C:\src` and Phoenix is in `C:\src\dotnet\Phoenix`.
6. Open PowerShell and navigate to your source directory.
7. Clone the repository: `git clone https://github.com/JXEnterprises/Phoenix.git`.
8. Change directory into the cloned repository: `cd Phoenix`.
9. Restore packages: `dotnet restore`.
10. Open the project in Visual Studio Code: `code .` or `code-insiders .` depending on what version you chose to install.
11. To debug, hit `F5`. Watch the `DEBUG CONSOLE` for diagnostic information such as web server directives, raw SQL sent to the database, and more!
12. Your default browser should open a new tab to the website. If you land on a page warning that your connection is not private, it is because you don't have a development certificate installed. You can "proceed anyway", since you know that the computer serving the site is, in fact, your own.

## Contributing

We use the [Git Flow](https://www.git-tower.com/learn/git/ebook/en/command-line/advanced-topics/git-flow) development methodology, which enables multiple team members to develop different features or fix bugs quickly while keeping merges to a minimum. We also use the industry-standard [Semantic Versioning scheme](https://semver.org/).

Contributions will be accepted only to invited collaborators such as JX employees, consultants, and contractors. If you encounter a security vulnerability, please [Email Us](hdesk@jxe.com).

## Change Log

### 0.3.0 (2018/07/11)

* Enhancement - Deals and Units now have a Many-to-Many relationship
* Enhancement - Added ControlBranch to Deal
* Bug Fix - Fixed how audit fields received their calculated values
* Bug Fix - No more duplicated foreign key references to Deal from Unit
* Bug Fix - Removed link to the Contact page
* Bug Fix - Inlined labels on Create page

### 0.2.0 (2018/07/05)

* Enhancement - Entity Framework integration
* Enhancement - "Start an Inspection" workflow created
* Enhancement - Documentation auto-creation
* Enhancement - SQL Server support
* Bug Fix - Routing fixed

### 0.1.0 (2018/06/28)

* Initial project creation, bundling & minification, tiered compilation, etc.