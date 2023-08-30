import PropTypes from 'prop-types';

const CustomerForm = ({ onCancel, onSave, disabled, isRegister }) => {

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

        {isRegister&&<div className="control">
        <label htmlFor="userName">Username:</label>
        <input
            name="userName"
            id="userName"
        />
        </div>}

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
            {isRegister? "Sign Up" : "Log In"}
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
    isRegister: PropTypes.bool,
  };

export default CustomerForm;