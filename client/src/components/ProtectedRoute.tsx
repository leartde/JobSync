// components/ProtectedRoute.tsx
import { Navigate, useLocation } from 'react-router-dom';
import { useAuth } from "../hooks/authentication/useAuth.ts";

const ProtectedRoute = ({ children, login }: { children,login }) => {
    const { user } = useAuth();
    const location = useLocation();

    if (!user && login) {
        return <Navigate to="/login" state={{ from: location }} replace />;
    }
    if (user && !login) {
        return <Navigate to="/" state={{ from: location }} replace />;
    }

    return children;
};

export default ProtectedRoute;