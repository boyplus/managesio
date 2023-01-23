import axios, { AxiosRequestConfig, AxiosResponse } from 'axios';
import { useEffect, useState } from 'react';

const useFetch = <T>(
  fetch: (options?: AxiosRequestConfig) => Promise<AxiosResponse<T, any>>
): [T | undefined, any, boolean] => {
  const [data, setUser] = useState<T>();
  const [error, setError] = useState<any>();
  const [status, setStatus] = useState<any>();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const fetchData = async () => {
    try {
      setIsLoading(true);

      const res = await fetch();
      const user = res.data;
      setUser(user);
    } catch (error: any) {
      if (axios.isAxiosError(error)) {
        setStatus(error.status);
      }
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return [data, error, isLoading];
};

export default useFetch;
