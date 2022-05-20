import { Navigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";

function AnonymousRoute({ children }) {
  const { isLoggedIn } = useAuthContext();

  if (isLoggedIn) {
    return <Navigate to={"/dashboard"} />;
  }
  return children;
}

export default AnonymousRoute;
