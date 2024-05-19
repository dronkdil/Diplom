"use client"
import { useReduxActions } from "@/hooks/useReduxActions"
import CourseExampleImage from "@public/images/CourseExample.png"
import { useEffect } from "react"
import styles from "./MyCertificates.module.scss"
import Certificate from "./certificates/Certificate"

const MyCertificatesPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Мої сертифікати") }, [])

  return (
    <>
      <div className={styles.certificates}>
        <Certificate 
          imageSrc={CourseExampleImage.src}
          title="Python"
          id={0}
        />
        <Certificate 
          imageSrc={CourseExampleImage.src}
          title="хмара обчислювальна техніка"
          id={0}
        />
      </div>
    </>
  )
}

export default MyCertificatesPage
