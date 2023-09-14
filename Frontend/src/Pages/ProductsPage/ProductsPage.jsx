import React from 'react';
import "./ProductsPage.css";
import ProductList from '../../Components/ProductCard/ProductList';
function ProductsPage() {
    return(
        <div>
        <h1>Product List</h1>
        <ProductList/>
        </div>
    );
}

export default ProductsPage;