"use client"
import { AuthenticationService } from "@/api/users/authentication/authentication.service"
import AuthenticationAvatar from "@/components/avatar/AuthenticationAvatar"
import { DefaultButton, IconButton } from "@/components/buttons"
import OnlyAuthenticatedUser from "@/components/guards/OnlyAuthenticatedUser"
import { DefaultLink } from "@/components/links"
import IconLink from "@/components/links/icon/IconLink"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { ProfileMenuItems } from "@/lib/profile-menu-items.constants"
import { getProfileTitle } from "@/lib/redux/slices/ProfileTitleSlice"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Routes } from "@/lib/routes.constants"
import { MenuIcon, PenIcon, XIcon } from "lucide-react"
import { usePathname, useRouter } from "next/navigation"
import { useEffect, useState } from "react"
import { useSelector } from "react-redux"
import styles from "./Profile.module.scss"
import StudentData from "./components/student-data/StudentData"

export type ProfileLayoutProps = {
    children: any
}

const ProfileLayout = ({children}: ProfileLayoutProps) => {
  const title = useSelector(getProfileTitle)
  const [isMenuOpened, setIsMenuOpened] = useState(false)
  const user = useSelector(getUserData)

  const pathname = usePathname()
  useEffect(() => {
    setIsMenuOpened(false)
  }, [pathname])

  const {logoutOnClient, clearUserData} = useReduxActions()
  const router = useRouter()

  const {mutateAsync: logout} = useTypedMutation({
      name: "logout",
      request: () => AuthenticationService.logout(),
      onSuccess: () => {
          router.push(Routes.Courses)
          logoutOnClient()
          clearUserData()
      }
  })

  return (
    <OnlyAuthenticatedUser>
      <div className="flex justify-center mt-3 md:mt-20">
        <div className={`${styles.left} ${isMenuOpened && styles["left--active"]}`}>
          <IconButton 
            className={styles.left__close}
            onClick={() => setIsMenuOpened(false)}
          >
			      <XIcon />
          </IconButton>
          <div className={styles.about}>
            <AuthenticationAvatar />
            <div className={styles.info}>
                <div className={styles.info__name}>{user?.displayName}</div>
                <div className={styles.info__data}>{user?.email}</div>
                {user?.role == "Student" && <StudentData />}
                <IconLink href={Routes.CommonUser.MyData} className={styles["info__edit-pen"]}><PenIcon /></IconLink>
            </div>
          </div>
          <div className={styles.buttons}>
              {ProfileMenuItems.map((o, i) => (user?.role == o.role || o.role == undefined) && 
                <DefaultLink key={i} href={o.href}>{o.text}</DefaultLink>)}
              <DefaultButton onClick={() => logout()}>Вийти</DefaultButton>
          </div>
        </div>
        <div className={`${styles.right} ${isMenuOpened && styles["right--hidden"]}`}>
          <h2 className={styles.right__title}>
            <IconButton 
              className={styles.right__open}
              onClick={() => setIsMenuOpened(true)}
            >
              <MenuIcon />
            </IconButton>
            {title}
          </h2>
          {children}
        </div>
      </div>
    </OnlyAuthenticatedUser>
  )
}

export default ProfileLayout
 