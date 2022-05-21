export const requestOptions = ({ value, method, isAuthenticated }) => {
  const config = {
    method,
    body: JSON.stringify(value),
    headers: {
      "Content-Type": "application/json",
    },
  };

  if (isAuthenticated) {
    config.headers["Authorization"] = `Bearer ${localStorage.getItem(
      "access-token"
    )}`;
  }

  return config;
};
