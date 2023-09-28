import PropTypes from "prop-types";
import "./ProductTable.css";

const ProductTable = ({ products, onDelete, onUpdate }) => {

  const onSubmit = async(e, id) => {
    e.preventDefault();
    console.log(e)
    console.log(e.target)

    const formData = new FormData(e.target);
    const updatedProduct = {};

    for (let [key, value] of formData.entries()) {
      updatedProduct[key] = value;
    }

    return onUpdate(updatedProduct, id);
  };

  return (
    <>
      <div className="product-list">
        <div className="product-list-title">PRODUCT LIST</div>
      </div>

      <div className="product-list-table">

        <table>
          <thead>
            <tr>
              <th className="th-product-id">Id</th>
              <th className="th-product-name">Product Name</th>
              <th className="th-quantity">Quantity</th>
              <th className="th-price">Unit Price</th>
              <th className="th-description">Description</th>
            </tr>
          </thead>
        </table>

        <div className="product-list-table-data">
          {products && products.map((product) => (
            <form key={product.id} onSubmit={(e) => onSubmit(e, product.id)}>
              <table>
                <tbody>
                  <tr key={product.id}>
                    <td className="product-id">{product.id}</td>
                    <td>
                      <input
                        className="product-name"
                        name="product-name"
                        defaultValue={product.productName}>
                      </input>
                    </td>
                    <td>
                      <input
                        className="product-quantity"
                        name="product-quantity"
                        defaultValue={product.quantity}>
                      </input>
                    </td>

                    <td>
                      <input
                        className="product-price"
                        name="product-price"
                        defaultValue={product.unitPrice}>
                      </input>
                    </td>

                    <td>
                      <input
                        className="product-description"
                        name="product-description"
                        defaultValue={product.description}>
                      </input>
                    </td>

                    <td className="update-delete-buttons">
                    <button className="update-user" type="submit">UPDATE</button>
                      <button className="delete-user" type="button" onClick={() => onDelete()}>
                        DELETE
                      </button>
                    </td>

                  </tr>
                </tbody>
              </table>
            </form>
          ))}</div>
      </div>
    </>
  );
};

// Add PropTypes validation for the `ProductList` prop
// (Specifies the types of props that a component should receive, it's generally considered good practice.
// PropTypes help catch type-related bugs early and make it clear what props a component expects)
ProductTable.propTypes = {
  products: PropTypes.array.isRequired,
  onUpdate: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
};

export default ProductTable;