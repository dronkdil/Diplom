import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Routes } from "@/lib/routes.constants"
import { cn } from "@/lib/utils"
import { PenIcon } from "lucide-react"
import { HTMLAttributes } from "react"
import { useSelector } from "react-redux"
import IconLink from "../../links/icon/IconLink"
import styles from "./Avatar.module.scss"

export type AvatarProps = HTMLAttributes<HTMLDivElement> & {
    isSmall?: boolean
    src?: string
    firstName: string
    lastName?: string
}

const Avatar = ({isSmall, className, src, firstName, lastName, ...rest}: AvatarProps) => {
    const user = useSelector(getUserData)

    return (
        <div className={cn(styles.avatar, isSmall ? styles["avatar--small"] : styles["avatar--normal"], className)} {...rest}>
            {src
                ? <img className={styles.avatar__image} src={src} alt={src} />
                : <div className={styles.avatar__empty}>
                    {`${firstName[0] + (lastName?.[0] ?? '')}`.toUpperCase()}
                </div>}
            {!isSmall && <IconLink href={Routes.CommonUser.MyData} className={styles["avatar__edit-pen"]}><PenIcon /></IconLink>}
        </div>
    )
}

export default Avatar