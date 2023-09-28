import { useEffect, useState } from "react";
import { useContext } from 'react';
import { UserContext } from '../main.jsx';
import ProductTable from "../Components/ProductTable/ProductTable";
const url = process.env.VITE_APP_MY_URL;

const updateProduct = (updatedProduct, email, user) => {
  console.log(email)
  console.log("PRODUCT UPDATE - PUT")

  return fetch(`${url}/api/Product/UpdateProduct`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
      'Authorization': 'Bearer ' + user.token
    },
    body: JSON.stringify(updatedProduct),
  })
    .then(data => {
      console.log('Product updated successfully:', data);
    })
    .catch(error => {
      console.error('Error updating product:', error);
      throw error;
    });
};

const deleteProduct = (id, user) => {
  console.log(email),
    console.log(user.userName, user.token),

    console.log("PRODUCT DELETE")
  return fetch(`${url}/api/Product/DeleteProductById?id=${id}`, {
    method: "DELETE",
    headers: {
      'Authorization': 'Bearer ' + user.token
    },
  });
};

const ProductList = () => {
  const [products, setProducts] = useState([]);
  const { user, setUser, login, logout } = useContext(UserContext);

  useEffect(() => {
    fetch(`${url}/api/Product/GetAll`)
      .then((res) => res.json())
      .then((product) => setProducts(product))
      .catch((error) => {
        console.error("Error fetching product list:", error);
      });
  }, [user.token]);

  if (products === null) {
    return <div>Loading...</div>;
  }

  const handleUpdate = (newProductName, id) => {
    console.log(id);
    console.log(newProductName["product-name"]);
    console.log("handleUpdate");

    let updatedProduct = products.find(c => c.id == id);
    updatedProduct.productName = newProductName["product-name"];

    console.log(updatedProduct);

    updateProduct(updatedProduct, id, user)
      .then(() => {
        //after a successful update, updating the local state as well
        setProducts(prevProducts => {
          const updatedProducts = prevProducts.map(c => {
            if (c.id === id) {
              return { ...c, productName: newProductName["product-name"] };
            }
            return c;
          });
          return updatedProducts;
        });
      });
  };

  const handleDelete = (email) => {
    console.log(email)
    console.log("handleDelete")
    deleteCustomer(email, user)
      .then(() => {
        //after a successful delete, updating the local state
        setCustomers(prevCustomers => prevCustomers.filter(c => c.email !== email));
      });
  }

  return (
    <div>
      <>
        <ProductTable
          products={products}
          onDelete={handleDelete}
          onUpdate={handleUpdate}
        />
      </>
    </div>
  );
};

export default ProductList;
