"use client"
import { DefaultLink, GhostLink } from "@/components/links"
import Logo from "@/components/logo/Logo"
import { getAuthenticated } from "@/lib/redux/slices/AuthenticationSlice"
import { Routes } from "@/lib/routes.constants"
import { useSelector } from "react-redux"
import styles from "./Header.module.scss"
import HeaderProfile from "./components/HeaderProfile"

const Header = () => {
  const isAuthenticated = useSelector(getAuthenticated)
  
  return (
    <div className={styles.header}>
      <Logo />
      {!isAuthenticated
        ? <div className={styles.header__auth}>
            <GhostLink href={Routes.Login}>Війти</GhostLink>
            <DefaultLink href={Routes.Registration}>Зареєструватись</DefaultLink>
          </div>
        : <HeaderProfile />
      }
    </div>
  )
}

export default Header
