import React from 'react';
import { Field } from 'formik';

export type InputProps = {
  label?: string;
  type?: string;
  name: string;
  touched?: boolean;
  error?: boolean;
}

const Input: React.FC<InputProps> = ({ label = "", type = "text", name, touched, error }) => {
  return (
    <div className='input-container'>
      <label>{label}</label>
      <Field type={type} name={name} />
      <div className='error-container'>
        {touched && error && <span>{error}</span>}
      </div>
    </div>
  );
}

export default Input;