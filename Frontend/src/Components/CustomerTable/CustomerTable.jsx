import "./CustomerTable.css";
import PropTypes from 'prop-types';

const CustomerTable = ({ customers, onDelete, onUpdate }) => {

  const onSubmit = async(e, email) => {
    e.preventDefault();
    console.log(e)
    console.log(e.target)

    const formData = new FormData(e.target);

    /*
    const entries = [...formData.entries()];

    const updatedCustomer = entries.reduce((acc, entry) => {
      const [k, v] = entry;
      acc[k] = v;
      return acc;
    }, {});*/

    const updatedCustomer = {};

    for (let [key, value] of formData.entries()) {
    updatedCustomer[key] = value;
    }

    return onUpdate(updatedCustomer, email);
  };

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

CustomerTable.propTypes = {
    customers: PropTypes.array.isRequired,
    onUpdate: PropTypes.func.isRequired,
    onDelete: PropTypes.func.isRequired,
  };

export default CustomerTable;