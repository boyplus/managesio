export const getToken = () => {
  const token = localStorage.getItem('jwt');
  return token;
};

export const saveToken = (token: string) => {
  localStorage.setItem('jwt', token);
};

export const deleteToken = () => {
  localStorage.removeItem('jwt');
};
