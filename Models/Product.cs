public class Product
{
  public Guid ProductId { get; set; }
  public required string Name { get; set; }
  public required decimal Price { get; set; }
  public string Image { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public required int Quantity { get; set; }
  public required int Sold { get; set; } = 0;
  public required decimal Shipping { get; set; }

  public required Guid CategoryId { get; set; }
  public Category? category { get; set; }

  public DateTime CreatedAt { get; set; }
}

// productId SERIAL PRIMARY KEY,
//  name VARCHAR(100) NOT NULL,
//  slug VARCHAR(100) UNIQUE NOT NULL,
//  image VARCHAR(100),
//  description TEXT,
//  price DECIMAL(10,2) NOT NULL,
//  quantity INT DEFAULT 0,
//  sold INT DEFAULT 0,
//  shipping DECIMAL(10,2) DEFAULT 0,
//  categoryId INT REFERENCES categories(categoryId),
//  createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP

// web api ecommerece 
