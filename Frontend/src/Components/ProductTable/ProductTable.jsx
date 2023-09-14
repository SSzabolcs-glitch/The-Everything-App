import PropTypes from "prop-types";
import "./ProductTable.css";

const ProductTable = ({ products }) => {

  return (
    <>
      <div className="customer-list">
        <div className="customer-list-title">CUSTOMER LIST</div>
      </div>

      <div className="customer-list-table">

        <table>
          <thead>
            <tr>
              <th className="th-username">Username</th>
              <th className="th-id">Id</th>
              <th className="th-email">Email</th>
            </tr>
          </thead>
        </table>

        <div className="customer-list-table-data">
          {customers && customers.map((customer) => (
            <form key={customer.email} onSubmit={(e) => onSubmit(e, customer.email)}>
              <table>
                <tbody>

                    <tr key={customer.id}>
                    <td>
                      <input
                        className="customer-username"
                        name="customer-username"
                        defaultValue={customer.userName}>
                      </input>
                    </td>
                    <td className="customer-id">{customer.id}</td>
                    <td className="customer-email">{customer.email}</td>
                    <td className="update-delete-buttons">
                      <button className="update-user" type="submit">UPDATE</button>
                      <button className="delete-user" type="button" onClick={() => onDelete(customer.email)}>
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
};

export default ProductTable;