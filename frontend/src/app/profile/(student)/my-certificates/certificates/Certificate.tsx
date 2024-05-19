import { IconButton } from "@/components/buttons"
import { Routes } from "@/lib/routes.constants"
import { DownloadCloudIcon, ForwardIcon } from "lucide-react"
import Image from "next/image"
import Link from "next/link"
import styles from "./Certificate.module.scss"

export type CertificateProps = {
    imageSrc: string
    title: string
    id: number
}

const Certificate = ({imageSrc, title, id}: CertificateProps) => {
  return (
    <div className={styles.wrapper}>
      <Link href={Routes.Profile.CertificateById(id)} className={styles.certificate}>
        <Image src={imageSrc} alt={title} className={styles.certificate__image} width={90} height={90} />
        <h4 className={styles.certificate__title}>{title}</h4>
      </Link>
      <div className={styles.certificate__buttons}>
        <IconButton><DownloadCloudIcon /></IconButton>
        <IconButton><ForwardIcon /></IconButton>
      </div>
    </div>
  )
}

export default Certificate
