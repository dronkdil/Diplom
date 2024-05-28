import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Routes } from "@/lib/routes.constants"
import { cn } from "@/lib/utils"
import { PenIcon } from "lucide-react"
import { HTMLAttributes } from "react"
import { useSelector } from "react-redux"
import IconLink from "../links/icon/IconLink"
import styles from "./Avatar.module.scss"

export type AvatarProps = HTMLAttributes<HTMLDivElement> & {
    isSmall?: boolean
}

const Avatar = ({isSmall, className, ...rest}: AvatarProps) => {
    const user = useSelector(getUserData)

    return (
        <div className={cn(styles.avatar, isSmall ? styles["avatar--small"] : styles["avatar--normal"], className)} {...rest}>
            {user.avatarUrl 
                ? <img className={styles.avatar__image} src={user.avatarUrl} alt={user.avatarUrl} />
                : <div className={styles.avatar__empty}>
                    {`${user?.firstName[0] + (user?.lastName?.[0] ?? '')}`.toUpperCase()}
                </div>}
            {!isSmall && <IconLink href={Routes.CommonUser.MyData} className={styles["avatar__edit-pen"]}><PenIcon /></IconLink>}
        </div>
    )
}

export default Avatar
