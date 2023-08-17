import PropTypes from 'prop-types';

const CustomerForm = ({ onCancel, onSave, disabled }) => {

    const onSubmit = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const entries = [...formData.entries()];
    
        const customer = entries.reduce((acc, entry) => {
          const [k, v] = entry;
          acc[k] = v;
          return acc;
        }, {});
    
        return onSave(customer);
    };

    return (
    <form className="CustomerForm" onSubmit={onSubmit}>

        <div className="control">
        <label htmlFor="firstName">First name:</label>
        <input
            name="firstName"
            id="firstName"
        />
        </div>

        <div className="control">
        <label htmlFor="lastName">Last name:</label>
        <input
            name="lastName"
            id="lastName"
        />
        </div>

        <div className="control">
        <label htmlFor="email">Email:</label>
        <input
            name="email"
            id="email"
        />
        </div>

        <div className="control">
        <label htmlFor="password">Password:</label>
        <input
            type="password"
            name="password"
            id="password"
        />
        </div>

        <div className="buttons">
        <button type="submit" disabled={disabled}>
            Sign Up
        </button>

        <button type="button" onClick={onCancel}>
            Cancel
        </button>
        </div>
    </form>
    );
};

CustomerForm.propTypes = {
    onCancel: PropTypes.func.isRequired,
    onSave: PropTypes.func.isRequired,
    disabled: PropTypes.bool.isRequired,
  };

export default CustomerForm;