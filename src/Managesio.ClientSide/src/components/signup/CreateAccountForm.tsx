import React from 'react';
import { withFormik, FormikProps, FormikErrors, Form, Field } from 'formik';

export interface CreateAccountFormValues {
  email: string;
  password: string;
}

export interface OwnProps {
  title: string;
}

const InnerForm = (props: OwnProps & FormikProps<CreateAccountFormValues>) => {
  const { touched, errors, isSubmitting, title } = props;
  return (
    <Form className='form-container'>
      <h2>{title}</h2>

      <Field type="password" name="password" />
      {touched.password && errors.password && <div>{errors.password}</div>}

      <button type="submit" disabled={isSubmitting}>
        Submit
      </button>
    </Form>
  );
};

interface MyFormProps {
  title: string;
  onSubmit: (values: CreateAccountFormValues) => void;
}

const CreateAccountForm = withFormik<MyFormProps, CreateAccountFormValues>({
  mapPropsToValues: props => {
    return {
      email: '',
      password: '',
    };
  },

  validate: (values: CreateAccountFormValues) => {
    let errors: FormikErrors<CreateAccountFormValues> = {};
    if (!values.email) {
      errors.email = 'Required';
    }
    return errors;
  },

  handleSubmit: values => {
    console.log(values)
    return new Promise(function (resolve) {
      setTimeout(resolve, 1000);
    });
  },
})(InnerForm);

export default CreateAccountForm;