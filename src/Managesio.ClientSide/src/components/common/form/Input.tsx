import React from 'react';
import { Field } from 'formik';

export type InputProps = {
  label?: string;
  type?: string;
  name: string;
  touched?: boolean;
  error?: string;
  placeholder?: string;
}

const Input: React.FC<InputProps> = ({ label = "", type = "text", name, touched, error, placeholder }) => {
  return (
    <div className='input-container'>
      <label>{label}</label>
      <Field
        type={type}
        name={name}
        placeholder={placeholder}
        style={{ marginTop: '5px' }}
      />
      <div className='error-container'>
        {touched && error && <span style={{ color: '#ff3333' }}>{error}</span>}
      </div>
    </div>
  );
}

export default Input;