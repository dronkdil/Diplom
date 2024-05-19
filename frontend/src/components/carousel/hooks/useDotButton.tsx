import { EmblaCarouselType } from 'embla-carousel'
import { useCallback, useEffect, useState } from "react"

type UseDotButtonType = {
    selectedIndex: number
    onDotButtonClick: (index: number) => void
}
  
export function useDotButton(emblaApi: EmblaCarouselType | undefined): UseDotButtonType {
    const [selectedIndex, setSelectedIndex] = useState(0)

    const onDotButtonClick = useCallback((index: number) => {
        if (emblaApi) emblaApi.scrollTo(index)
    }, [emblaApi])

    const onSelect = useCallback((emblaApi: EmblaCarouselType) => {
        setSelectedIndex(emblaApi.selectedScrollSnap())
    }, [])

    useEffect(() => {
        if (!emblaApi) return

        onSelect(emblaApi)
        emblaApi.on('reInit', onSelect)
        emblaApi.on('select', onSelect)
}, [emblaApi, onSelect])

    return {
        selectedIndex,
        onDotButtonClick
    }
}
