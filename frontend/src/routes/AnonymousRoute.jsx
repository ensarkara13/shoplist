import { Navigate } from "react-router-dom";
import { useAuthContext } from "../contexts/authContext";

function AnonymousRoute({ children }) {
  const { isLoggedIn, currentLocation } = useAuthContext();

  if (isLoggedIn) {
    return <Navigate to={currentLocation} />;
  }
  return children;
}

export default AnonymousRoute;
