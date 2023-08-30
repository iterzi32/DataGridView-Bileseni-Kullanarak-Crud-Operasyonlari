using DataGridViewWinFormExample.DefaultMessages;
using DataGridViewWinFormExampleBusiness.Interfaces;
using DataGridViewWinFormExampleBusiness.IOC;
using DataGridViewWinFormExampleDto.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = DataGridViewWinFormExample.DefaultMessages.Message;

namespace DataGridViewWinFormExample.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly IProductService productService;
        private ProductListDto selectedProductListDto;
        public ProductListForm()
        {
            InitializeComponent();
            BusinessLayerDependencyService service = new BusinessLayerDependencyService();
            productService = service.GetProductManagerInstance();
        }

        private void LoadProduct()
        {
            dataGridViewProduct.DataSource = null;
            dataGridViewProduct.DataSource = productService.GetAll();
        }      
        
        private void Clear()
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                txtProductName.Text = string.Empty;
                txtPrice.Text = string.Empty;
            }
        }
        
        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }
        
        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = dataGridViewProduct.Rows[e.RowIndex];
                if (row != null)
                {
                    selectedProductListDto = new ProductListDto();
                    selectedProductListDto.Id = (int)(row.Cells[0].Value);
                    selectedProductListDto.Name = (string)(row.Cells[1].Value);
                    selectedProductListDto.Price = (int)(row.Cells[2].Value);

                    txtProductName.Text = selectedProductListDto.Name;
                    txtPrice.Text = selectedProductListDto.Price.ToString();
                }
            }
        }        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                ProductCreateDto productCreateDto = new ProductCreateDto();
                productCreateDto.Name = txtProductName.Text;
                productCreateDto.Price = int.Parse(txtPrice.Text);

                productService.Add(productCreateDto);
                LoadProduct();
                Clear();
                MessageBox.Show(Message.SUCCESSFUl);
            }
            else
            {
                MessageBox.Show(Message.WARNING);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                ProductDeleteDto productDeleteDto = new ProductDeleteDto();
                productDeleteDto.Id = selectedProductListDto.Id;
                productService.Delete(productDeleteDto);
                LoadProduct();
                Clear();
                MessageBox.Show(Message.SUCCESSFUl);
            }
            else
            {
                MessageBox.Show(Message.WARNING);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductName.Text) && !string.IsNullOrEmpty(txtPrice.Text))
            {
                ProductUpdateDto productUpdateDto = new ProductUpdateDto();
                productUpdateDto.Id = selectedProductListDto.Id;
                productUpdateDto.Name = txtProductName.Text;
                productUpdateDto.Price = int.Parse(txtPrice.Text);
                productService.Update(productUpdateDto);
                LoadProduct();
                Clear();
                MessageBox.Show(Message.SUCCESSFUl);
            }
            else
            {
                MessageBox.Show(Message.WARNING);
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
