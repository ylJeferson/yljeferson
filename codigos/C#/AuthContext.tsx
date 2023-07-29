import {createContext, useEffect, useState } from "react";
import {setCookie, parseCookies} from 'nookies';

import { recoverUserInformation, signInRequest } from "../services/auth";
import Router, { useRouter } from "next/router";
import { api } from "../services/api";


type signInData = {
    email: string;
    password: string;
}

type User = {
    name: string;
    email: string;
}

type AuthContextType = {
    isAuthenticated: boolean;
    user: User | null;
    signIn: (data: signInData) => Promise<void>;
    
}

export const AuthContext = createContext({} as AuthContextType)

export function AuthProvider ({children}: any){

    // console.log(children)

    const [user, setUser] = useState <User | null>(null)
    const [redirect, setRedirect] = useState <String | null>(null)

    const isAuthenticated = !!user;

    useEffect(() => {
        const {'app-token': token} = parseCookies()

        if (token){

            // recoverUserInformation().then(response => {

            //     if(response.response === "unauthorized"){
            //         setRedirect("/login")
            //     }
            //     else{
            //         setUser(response.user)
            //         console.log(response)
            //     }

                
            // })

            
        }

    }, [])


    async function signIn ({email, password}: signInData){

        console.log("signIn", email, password)
        
        const {token, user} = await signInRequest({
            email,
            password
        })

        console.log("signIn", token, user)

        setCookie(undefined, 'app-token', token, {
            maxAge: 10 * 60,  // 10 minutes
        })


        api.defaults.headers.common['authorization'] = `bearer ${token}`

        console.log("token",token)

        setUser(user)

        Router.push('/files/app')
    }

    // console.log("user context", user)

    return (
        <AuthContext.Provider value={{user, isAuthenticated, signIn}}>
            {children}
        </AuthContext.Provider>
    )
}