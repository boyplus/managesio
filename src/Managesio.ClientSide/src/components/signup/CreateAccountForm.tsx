import React from 'react';
import { withFormik, FormikProps, FormikErrors, Form } from 'formik';
import Input from '@/components/common/form/Input';

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
      <Input
        type="email"
        name="email"
        label="Email"
        placeholder='Email'
        touched={touched.email}
        error={errors.email}
      />
      <Input
        type="password"
        name="password"
        label="Password"
        placeholder='Password'
        touched={touched.password}
        error={errors.password}
      />


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