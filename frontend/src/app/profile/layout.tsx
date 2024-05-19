"use client"
import { DefaultButton, IconButton } from "@/components/buttons"
import { DefaultLink } from "@/components/links"
import { getProfileTitle } from "@/lib/redux/slices/ProfileTitleSlice"
import { Routes } from "@/lib/routes.constants"
import { ArrowLeftIcon, PenIcon, XIcon } from "lucide-react"
import { usePathname } from "next/navigation"
import { useEffect, useState } from "react"
import { useSelector } from "react-redux"
import styles from "./Profile.module.scss"

export type ProfileLayoutProps = {
    children: any
}

const ProfileLayout = ({children}: ProfileLayoutProps) => {
  const title = useSelector(getProfileTitle)
  const [isMenuOpened, setIsMenuOpened] = useState(false)

  const pathname = usePathname()
  useEffect(() => {
    setIsMenuOpened(false)
  }, [pathname])

  return (
    <div className="flex justify-center mt-3 md:mt-20">
      <div className={`${styles.left} ${isMenuOpened && styles["left--active"]}`}>
        <IconButton 
          className={styles.left__close}
          onClick={() => setIsMenuOpened(false)}
        >
          <XIcon />
          </IconButton>
        <div className={styles.about}>
          <div className={styles.avatar}>
              DS
              <IconButton className={styles["avatar__edit-pen"]}><PenIcon /></IconButton>
          </div>
          <div className={styles.info}>
              <div className={styles.info__name}>Denis Shevchuk</div>
              <div className={styles.info__data}>Вища освіта</div>
              <div className={styles.info__data}>17.01.2023</div>
              <div className={styles.info__data}>18 років</div>
              <div className={styles.info__data}>destr20202@gmail.com</div>
              <IconButton className={styles["info__edit-pen"]}><PenIcon /></IconButton>
          </div>
        </div>
        <div className={styles.buttons}>
            <DefaultLink href={Routes.Profile.Courses}>Мої курси</DefaultLink>
            <DefaultLink href={Routes.Profile.Certificates}>Мої сертифікати</DefaultLink>
            <DefaultLink href={Routes.Profile.Notification}>Повідомлення</DefaultLink>
            <DefaultLink href={Routes.Profile.MyData}>Власні дані</DefaultLink>
            <DefaultLink href={Routes.Profile.Settings}>Налаштування</DefaultLink>
            <DefaultButton>Вийти</DefaultButton>
        </div>
      </div>
      <div className={`${styles.right} ${isMenuOpened && styles["right--hidden"]}`}>
        <h2 className={styles.right__title}>
          <IconButton 
            className={styles.right__open}
            onClick={() => setIsMenuOpened(true)}
          >
            <ArrowLeftIcon />
          </IconButton>
          {title}
        </h2>
        {children}
      </div>
    </div>
  )
}

export default ProfileLayout
 