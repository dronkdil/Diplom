"use client"
import { AccentButton, DefaultButton } from '@/components/buttons'
import { ListboxInput } from '@/components/form'
import { DefaultInput } from '@/components/form/input'
import { Disclosure, DisclosureButton, DisclosurePanel } from '@headlessui/react'
import { AlignLeftIcon, CandlestickChartIcon, DownloadCloudIcon } from 'lucide-react'
import Link from 'next/link'
import styles from "./Homework.module.scss"

export type HomeworkProps = {
    
}

const Homework = () => {
  return (
    <Disclosure as={"div"} className={styles.homework}>
        {({open}) =>  <>
            <div className={styles.homework__header}>
                <Link href={"/"} target='_blank' className={styles.homework__student}>Денис Шевчук</Link>
                <DisclosureButton>
                    <DefaultButton>{open ? "Закрити" : "Оцінити"}</DefaultButton>
                </DisclosureButton>
            </div>
            <DisclosurePanel className={styles.homework__content}>
                <div>
                    <h4 className={styles.homework__description}>Перевірте дз та поставте оцінку</h4>
                    {Array.from(Array(4).keys()).map((_, i) => <div className={styles.homework__file}>
                        <span>Назва файлу</span>
                        <DownloadCloudIcon />
                    </div>)}
                </div>
                <div className={styles.homework__form}>
                    <ListboxInput values={["відсутня", 1, 2, 3, 4, 5].map(o => ({id:0, text:o}))} icon={<CandlestickChartIcon />} placeholder='Оцінка' />
                    <DefaultInput icon={<AlignLeftIcon />} placeholder='Коментар' />
                    <AccentButton>Підтвердити</AccentButton>
                </div>
            </DisclosurePanel>
        </>}
    </Disclosure>
  )
}

export default Homework
