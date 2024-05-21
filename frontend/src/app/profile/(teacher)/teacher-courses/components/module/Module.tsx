import { IconButton } from '@/components/buttons'
import { Disclosure, DisclosureButton, DisclosurePanel } from '@headlessui/react'
import { ChevronDownIcon, PencilIcon } from 'lucide-react'
import styles from "./Module.module.scss"

export type ModuleProps = {
    title: string
    children: any
}

const Module = ({title, children}: ModuleProps) => {
  return (
    <Disclosure as={"div"} className={styles.module}>
        <DisclosureButton className={styles.module__header}>
            <span className={styles.module__title}>{title}</span>
            <IconButton><PencilIcon /></IconButton>
            <IconButton className={styles["module__down-icon"]}><ChevronDownIcon /></IconButton>
        </DisclosureButton>
        <DisclosurePanel className={styles.module__items}>
            {children}
        </DisclosurePanel>
    </Disclosure>
  )
}

export default Module
