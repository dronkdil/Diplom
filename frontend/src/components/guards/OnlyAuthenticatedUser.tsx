import { getAuthenticated } from "@/lib/redux/slices/AuthenticationSlice"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { useSelector } from "react-redux"

type OnlyAuthenticatedUserProps = {
    children: any
    role?: string
}

const OnlyAuthenticatedUser = ({children, role}: OnlyAuthenticatedUserProps) => {
    const isAuthenticated = useSelector(getAuthenticated)
    const user = useSelector(getUserData)

    if (!isAuthenticated || !user)
        return <div className="flex-auto flex justify-center items-center text-white relative pb-[40px]">
            401 | Ви не авторизовані
        </div>

    if (role && user.role != role)
        return <div className="flex-auto flex justify-center items-center text-white relative pb-[40px]">
            403 | Відмовлено в доступі
        </div>

    return (
        <>
            {children}
        </>
    )
}

export default OnlyAuthenticatedUser
