<h1>📦 Customer Delivery Management System - ASP.NET Core MVC</h1>

<p>This is an ASP.NET Core MVC application that allows you to manage <strong>customers</strong> along with their associated <strong>delivery addresses</strong>. The system supports <strong>CRUD operations</strong>, dynamic form inputs, and a Bootstrap-powered responsive UI.</p>

<h2>🌐 Tech Stack</h2>
<table>
    <tr><th>Layer</th><th>Technology</th></tr>
    <tr><td>Backend</td><td>ASP.NET Core MVC (.NET 8)</td></tr>
    <tr><td>ORM</td><td>Entity Framework Core</td></tr>
    <tr><td>Frontend</td><td>Razor Views, HTML5, Bootstrap 5</td></tr>
    <tr><td>Scripting</td><td>JavaScript, jQuery</td></tr>
    <tr><td>Database</td><td>SQL Server (Express)</td></tr>
</table>

<h2>📁 Project Structure</h2>

<h3>🧾 Models</h3>

<h4>Customer.cs</h4>
<pre><code>public class Customer {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }
    [NotNull]
    public string CustomerName { get; set; }
    public DateTime BusinessStart { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public decimal CreditLimit { get; set; }
    public string? CustomerType { get; set; }
    public string? Photo { get; set; }
    public virtual IList&lt;DeliveryAddress&gt; DeliveryAddresses { get; set; } = new List&lt;DeliveryAddress&gt;();
}
</code></pre>

<h4>DeliveryAddress.cs</h4>
<pre><code>public class DeliveryAddress {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeliveryAddressId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public string? ContactPerson { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}
</code></pre>

<h2>📦 Database Context</h2>
<pre><code>public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) {}
    public DbSet&lt;Customer&gt; Customers { get; set; }
    public DbSet&lt;DeliveryAddress&gt; DeliveryAddresses { get; set; }
}
</code></pre>

<h2>🖥️ Views</h2>

<h3>✅ Index View (Views/Customers/Index.cshtml)</h3>
<ul>
    <li>Lists all customers</li>
    <li>Includes partial view for create/edit: <code>_Create.cshtml</code></li>
</ul>

<h3>🧩 Partial View - _Create.cshtml</h3>
<ul>
    <li>Form for customer creation/edit</li>
    <li>Dynamic input rows for delivery addresses</li>
    <li>File input for photo</li>
</ul>

<h2>🔌 Connection String</h2>
<pre><code>{
  "ConnectionStrings": {
    "connection": "Server=DESKTOP-FRGGIBC\\SQLEXPRESS;Database=EvPractice_10;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
  }
}
</code></pre>

<h2>🛠️ How to Run the Project</h2>
<ol>
    <li>Clone the Repository</li>
    <pre><code>git clone &lt;your-repo-url&gt;</code></pre>

    <li>Update the DB Connection</li>
    <li>Run Migrations</li>
    <pre><code>dotnet ef database update</code></pre>

    <li>Run the App</li>
    <pre><code>dotnet run</code></pre>

    <li>Open Browser</li>
    <pre><code>https://localhost:5001</code></pre>
</ol>

<h2>✅ Features</h2>
<ul>
    <li>Create/Edit/Delete Customers</li>
    <li>Dynamic delivery address inputs</li>
    <li>Bootstrap form styling</li>
    <li>File upload support</li>
    <li>Reusable Razor Partial View</li>
</ul>

<h2>📜 License</h2>
<p>This project is developed for learning/demo purpose. Feel free to use or modify as needed.</p>
