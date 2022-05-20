import { Navigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";

function ProtectedRoute({ children }) {
  const { isLoggedIn } = useAuthContext();

  if (isLoggedIn) {
    return children;
  }
  return <Navigate to={"/"} />;
}

export default ProtectedRoute;
