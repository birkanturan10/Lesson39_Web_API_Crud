using Lesson39_Web_API_Crud.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson39_Web_API_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
        public static List<Product> urunler = new List<Product>
        {
            new Product{ProductID=1,ProductName="Ürün 1",UnitPrice=1000,UnitsInStock=10},
            new Product{ProductID=2,ProductName="Ürün 2",UnitPrice=2000,UnitsInStock=20},
            new Product{ProductID=3,ProductName="Ürün 3",UnitPrice=3000,UnitsInStock=30},
            new Product{ProductID=4,ProductName="Ürün 4",UnitPrice=4000,UnitsInStock=40}
        };

        //Listeleme
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(urunler);
        }

        //ID ile çekme
        [HttpGet("{ID}")]
        public async Task<ActionResult<Product>> Get(int ID)
        {
            var urun = urunler.Find(p => p.ProductID == ID);
            if (urun == null)
            {
                return BadRequest("Ürün bulunamadı.");
            }
            return Ok(urun);
        }

        //Ekleme
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            urunler.Add(product);
            return Ok(urunler);
        }

        //Güncelleme
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var urun = urunler.Find(p => p.ProductID == product.ProductID);
            if (urun == null)
            {
                return BadRequest("Ürün bulunamadı.");
            }
            urun.ProductName = product.ProductName;
            urun.UnitPrice = product.UnitPrice;
            urun.UnitsInStock = product.UnitsInStock;

            return Ok(urunler);
        }

        //Silme
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int ID)
        {
            var urun = urunler.Find(p => p.ProductID == ID);
            if (urun==null)
            {
                return BadRequest("Ürün bulunamadı.");
            }
            urunler.Remove(urun);
            return Ok(urun);
        }
        */

        private readonly DataContext context;
        public ProductsController(DataContext context)
        {
            this.context = context;
        }

        //Listeleme
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await context.Products.ToListAsync());
        }

        //ID ile çekme
        [HttpGet("{ID}")]
        public async Task<ActionResult<Product>> Get(int ID)
        {
            var urun = await context.Products.FindAsync(ID);
            if (urun==null)
            {
                return BadRequest("Ürün bulunamadı.");
            }
            return Ok(urun);
        }

        //Ekleme
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Ok(await context.Products.ToListAsync());
        }

        //Güncelleme
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var urun = await context.Products.FindAsync(product.ProductID);
            if (urun==null)
            {
                return BadRequest("Ürün bulunamadı.");
            }
            urun.ProductName = product.ProductName;
            urun.UnitPrice = product.UnitPrice;
            urun.UnitsInStock = product.UnitsInStock;
            await context.SaveChangesAsync();
            return Ok(await context.Products.ToListAsync());
        }

        //Silme
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int ID)
        {
            var urun = await context.Products.FindAsync(ID);
            if (urun==null)
            {
                return BadRequest("Ürün bulunamadı");
            }
            context.Products.Remove(urun);
            await context.SaveChangesAsync();
            return Ok(await context.Products.ToListAsync());
        }
    }
}
