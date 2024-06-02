import { getUserData } from "@/lib/redux/slices/UserSlice"
import { HTMLAttributes } from "react"
import { useSelector } from "react-redux"
import Avatar from "./default/Avatar"

export type AuthenticationAvatarProps = HTMLAttributes<HTMLDivElement> & {
    isSmall?: boolean
}

const AuthenticationAvatar = (props: AuthenticationAvatarProps) => {
    const user = useSelector(getUserData)

    return <Avatar
        src={user.avatarUrl}
        firstName={user?.firstName}
        lastName={user?.lastName}
        {...props}
    />
}

export default AuthenticationAvatar
