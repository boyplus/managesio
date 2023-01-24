import React from 'react';
import Layout from '@/components/layout/Layout';
import CreateAccountForm, { CreateAccountFormValues } from '@/components/signup/CreateAccountForm';


import '@/styles/signup.css';


const Signup: React.FC = () => {

  const onSubmit = (values: CreateAccountFormValues) => {
    console.log(values);
  }
  return (
    <Layout>
      <div className='signup-container'>
        <CreateAccountForm
          title="Create new account"
          onSubmit={onSubmit}
        />
      </div>
    </Layout>
  )
}

export default Signup;