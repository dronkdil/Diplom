import { Routes } from '@/lib/routes.constants'
import Link from 'next/link'
import styles from './Logo.module.scss'

const Logo = () => {
  return (
    <Link href={Routes.Home} className={styles.logo}>
      <div className={styles.logo__cube}></div>
      <span className={styles.logo__text}>StudyEra</span>
    </Link>
  )
}

export default Logo
