import { useEffect, useState } from "react";
import ProductTable from "../Components/ProductTable/ProductTable";

const ProductList = () => {
  const [products, setProducts] = useState(null);
  const url = process.env.VITE_APP_MY_URL;

  useEffect(() => {
    fetch(`${url}/api/Product/GetAll`)
      .then((res) => res.json())
      .then((product) => setProducts(product))
      .catch((error) => {
        console.error("Error fetching product list:", error);
      });
  }, []);

  if (products === null) {
    return <div>Loading...</div>;
  }

  return <ProductTable products={products}/>;
};

export default ProductList;
