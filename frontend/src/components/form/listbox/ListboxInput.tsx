"use client"
import { Listbox, ListboxButton, ListboxOption, ListboxOptions } from "@headlessui/react"
import { useState } from "react"
import InputWrapper from "../input/wrapper/InputWrapper"
import styles from "./ListboxInput.module.scss"

export type ListboxInputProps = {
    values: any[]
    icon: React.ReactElement
    placeholder?: string
}

const ListboxInput = ({values, icon, placeholder, ...props}: ListboxInputProps) => {
    const [value, setValue] = useState(null)

    return (
        <Listbox  
            value={value} 
            onChange={setValue}
            className={styles.listbox}
            as={"div"}
        >
            <ListboxButton className="w-full">
                <InputWrapper icon={icon} onFocus={() => {}} wrapperClassName="w-full">
                    {value ? <span className="text-white">{value}</span> : <span    className="text-white/50">{placeholder}</span>}
                </InputWrapper>
            </ListboxButton>
            <ListboxOptions  anchor="bottom start" className={styles['combobox-options']}>
                {values.map((o, i) => (
                    <ListboxOption key={i} value={o} className={styles['combobox-options__item']}>
                        {o}
                    </ListboxOption>
                ))}
            </ListboxOptions>
        </Listbox>
    )

}

export default ListboxInput
