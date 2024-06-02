"use client"
import { AuthenticationService } from "@/api/users/authentication/authentication.service"
import AuthenticationAvatar from "@/components/avatar/AuthenticationAvatar"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { ProfileMenuItems } from "@/lib/profile-menu-items.constants"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Routes } from "@/lib/routes.constants"
import { Menu, MenuButton, MenuItem, MenuItems, Transition } from "@headlessui/react"
import Link from "next/link"
import { useRouter } from "next/navigation"
import { useSelector } from "react-redux"
import styles from "./HeaderProfile.module.scss"

const HeaderProfile = () => {
    const user = useSelector(getUserData)
    const {logoutOnClient, clearUserData} = useReduxActions()
    const router = useRouter()

    const {mutateAsync: logout} = useTypedMutation({
        name: "logout",
        request: () => AuthenticationService.logout(),
        onSuccess: () => {
            router.push(Routes.Courses)
            logoutOnClient()
            // clearUserData()
        }
    })

    return (
        <Menu as={"div"} className={styles.menu}>
            <MenuButton>
                {({active}) => <div className={`${styles.profile} ${active && styles["profile--active"]}`}>
                    {/* <div className={styles.profile__image}>{`${user.firstName[0] + (user.lastName?.[0] ?? '')}`.toUpperCase()}</div> */}
                    <AuthenticationAvatar isSmall />
                    <div className={styles.profile__info}>
                        <div className={styles.profile__name}>{user.displayName}</div>
                        <div className={styles.profile__email}>{user.email}</div>
                    </div>
                </div>}
            </MenuButton>
            <Transition
                enter="duration-100 ease-in"
                enterFrom="scale-95 opacity-0"
                enterTo="scale-100 opacity-100"
                leave="duration-100 ease-in"
                leaveFrom="scale-100 opacity-100"
                leaveTo="scale-95 opacity-0"
            >
                <MenuItems as={"div"} className={styles.menu__items}>
                    {ProfileMenuItems.map((o, i) => (user.role == o.role || o.role == undefined) && <MenuItem as={"div"} key={i}>
                        <Link href={o.href} className={styles.menu__link}>{o.text}</Link>
                    </MenuItem>)}
                    <MenuItem>
                        <button className={styles.menu__link} onClick={() => logout()}>Вийти</button>
                    </MenuItem>
                </MenuItems>
            </Transition>
        </Menu>
    )
}

export default HeaderProfile
