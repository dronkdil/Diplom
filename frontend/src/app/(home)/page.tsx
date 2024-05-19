'use client'
import FirstImage from "@/../public/images/slides/present/teaching.svg"
import Carousel from "@/components/carousel/Carousel"
import { GhostLink } from "@/components/links"
import { Routes } from "@/lib/routes.constants"
import Image from "next/image"
import styles from "./Page.module.scss"

export default function Home() {
  return (
    <div className="flex-auto flex justify-center items-center">
      <Carousel 
        className={styles.carousel} 
        footerClassName={styles.carousel__footer} 
        buttonsClassName={styles.carousel__buttons} 
        additionalButtons={<GhostLink href={Routes.Courses}>Пропустити</GhostLink>}
      >
        <div className={styles.slide}>
            <Image src={FirstImage.src} alt="first" width={350} height={250} />
            <div className={styles.slide__content}>
              <h2 className={styles.slide__title}>Навчайся разом з нами</h2>
              <p className={styles.slide__p}>Ваш особистий розвиток починається тут. Оберіть курси, які вас зацікавлять, і розвивайтеся з нами.</p>
            </div>
		    </div>
        <div className={styles.slide}>
            <Image src={FirstImage.src} alt="first" width={350} height={250} />
            <div className={styles.slide__content}>
              <h2 className={styles.slide__title}>Навчайся разом з нами</h2>
              <p className={styles.slide__p}>Ваш особистий розвиток починається тут. Оберіть курси, які вас зацікавлять, і розвивайтеся з нами.</p>
            </div>
		    </div>
        <div className={styles.slide}>
            <Image src={FirstImage.src} alt="first" width={350} height={250} />
            <div className={styles.slide__content}>
              <h2 className={styles.slide__title}>Навчайся разом з нами</h2>
              <p className={styles.slide__p}>Ваш особистий розвиток починається тут. Оберіть курси, які вас зацікавлять, і розвивайтеся з нами.</p>
            </div>
		    </div>
      </Carousel>
    </div>
  )
}
