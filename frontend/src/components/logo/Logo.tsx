import { Routes } from '@/lib/routes.constants'
import Image from 'next/image'
import Link from 'next/link'
import LogoImage from '../../../public/images/Logo.jpg'
import styles from './Logo.module.scss'

const Logo = () => {
  return (
    <Link href={Routes.Courses} className={styles.logo}>
      <Image src={LogoImage.src} width={40} height={40} alt="logo" className={styles.logo__cube} />
      <span className={styles.logo__text}>StudyEra</span>
    </Link>
  )
}

export default Logo
