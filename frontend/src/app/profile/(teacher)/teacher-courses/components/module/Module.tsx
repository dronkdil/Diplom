import { IconButton } from '@/components/buttons'
import IconLink from '@/components/links/icon/IconLink'
import { Routes } from '@/lib/routes.constants'
import { Disclosure, DisclosureButton, DisclosurePanel } from '@headlessui/react'
import { ChevronDownIcon, SettingsIcon, TrashIcon } from 'lucide-react'
import styles from "./Module.module.scss"

export type ModuleProps = {
    title: string
    description: string
    children: any
    id: number
}

const Module = ({title, children, id, description}: ModuleProps) => {
  return (
    <Disclosure as={"div"} className={styles.module}>
      {({open}) => <>
        <DisclosureButton className={styles.module__header}>
            <span className={styles.module__title}>{title}</span>
            <IconButton className={`${styles["module__down-icon"]} ${open && styles["module__down-icon--active"]}`}><ChevronDownIcon /></IconButton>
            <IconLink href={Routes.Teacher.ModuleSettings(id)}><SettingsIcon /></IconLink>
            <IconButton><TrashIcon /></IconButton>
        </DisclosureButton>
        <DisclosurePanel className={styles.module__items}>
            <p className={styles.module__description}>{description}</p>
            {children}
        </DisclosurePanel>
      </>}
    </Disclosure>
  )
}

export default Module
