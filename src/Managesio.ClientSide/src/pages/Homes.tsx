import React, { useEffect, useState } from 'react';
import { todoApi } from '../api';
import { Todo } from '../api/generated';
import { saveToken, deleteToken } from '../auth';
import globalAxios from 'axios';
import Layout from '../components/layout/Layout';

const Home: React.FC = () => {
  const [todos, setTodos] = useState<Todo[]>([]);

  const fetchTodos = async () => {
    const res = await todoApi.getTodos();
    setTodos(res.data);
  }

  const login = () => {
    const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjljYmEwMDI5LWVkNTEtNGQ3NS05Y2Q4LWQwNTg3ZmM4ZWUzOSIsIm5iZiI6MTY3NDQ0MjI0MCwiZXhwIjoxNjc1MDQ3MDQwLCJpYXQiOjE2NzQ0NDIyNDB9.MMku2xHlCYHsMm-5BELO2otlj7mIr9vjORTGYKNBdBI';
    saveToken(token);
    globalAxios.defaults.headers.common = { 'Authorization': `Bearer ${token}` }
  }

  const logout = () => {
    deleteToken();
  }

  useEffect(() => {
    fetchTodos();
  }, [])

  return (
    <Layout>
      <h1>Project Management App</h1>
      <h2 onClick={login}>Login</h2>
      <h2 onClick={logout}>Logout</h2>
      {todos.map(todo => {
        return <div>
          <h3>{todo.title}</h3>
        </div>
      })}
    </Layout>
  );
}

export default Home;