import React from 'react';
import "./ProductsPage.css";
import ProductList from '../../Components/ProductCard/ProductList';
function ProductsPage() {
    return(
        <div>
        <div className="white-bar"></div>
        <div className='main-product-container'>
            <div className='product-list-title-text'>Product List</div>
            <div className='product-list-product-cards'>
                <ProductList/>
            </div>
        </div>
        </div>
    );
}

export default ProductsPage;