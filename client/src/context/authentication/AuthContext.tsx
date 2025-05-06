import { createContext, useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";
import { User } from "../../types/authentication/User.ts";
import Logout from "../../services/authentication/Logout.ts";
type UserClaims = {
    id: string;
    email: string;
    role: "jobseeker" | "employer" | "admin";
};


type AuthContextType = {
    user: User | null;
    login: (tokens: { accessToken: string; refreshToken: string }, rememberMe: boolean) => Promise<void>;
    logout: () => Promise<void>;
};

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({children}: {children}) => {
    const [user, setUser] = useState<User | null>(null);

    useEffect(() => {
        const initializeAuth = async () => {
            try {
                const cookies = document.cookie.split(';').reduce((acc, cookie) => {
                    const [name, value] = cookie.trim().split('=');
                    return { ...acc, [name]: value };
                }, {} as Record<string, string>);

                if (cookies.accessToken) {
                    const decoded = jwtDecode(cookies.accessToken) as UserClaims;
                    const user: User = {
                        id: decoded.id,
                        email: decoded.email,
                        role: decoded.role,
                    };
                    setUser(user);
                }
            } catch (error) {
                console.error("Auth initialization error:", error);
            }
        };
        initializeAuth().then();
    }, []);

    const login = async (tokens: {accessToken: string, refreshToken: string}, rememberMe: boolean) => {
        try {
            const decodedToken = jwtDecode(tokens.accessToken) as UserClaims;
            const user: User = {
                id: decodedToken.id,
                email: decodedToken.email,
                role: decodedToken.role,
            };

            setUser(user);

            if (rememberMe) {
                localStorage.setItem("rememberMe", "true");
            } else {
                localStorage.removeItem("rememberMe");
            }
        } catch (error) {
            console.error("Login error:", error);
            throw error;
        }
    };

    const logout = async () => {
        await Logout();
        setUser(null);
        localStorage.removeItem("rememberMe");
    }

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );

    }


