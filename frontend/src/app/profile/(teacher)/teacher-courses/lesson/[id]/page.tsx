"use client"
import { LessonService } from "@/api/materialsForStudy/lesson/lesson.service"
import { LessonForPageType } from "@/api/materialsForStudy/lesson/type/lesson-for-page.type"
import { UpdateLessonDescriptionType } from "@/api/materialsForStudy/lesson/type/update-description.type"
import { UpdateLessonHomeworkType } from "@/api/materialsForStudy/lesson/type/update-homework.type"
import { UpdateLessonTitleType } from "@/api/materialsForStudy/lesson/type/update-title.type"
import { UpdateLessonVideoByUrlType } from "@/api/materialsForStudy/lesson/type/update-video-by-url.type"
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput } from "@/components/form/input"
import Setting from "@/components/setting/Setting"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { SquarePenIcon, VideoIcon } from "lucide-react"
import { useParams } from "next/navigation"
import { useEffect } from "react"
import { Controller } from "react-hook-form"

const LessonPage = () => {
    const {id} = useParams()
    
    const {data, setData} = useTypedQuery<LessonForPageType>({
      name: `get-lesson-for-settings-${id}`,
      request: () => LessonService.getForPage(Number(id)),
    })

    const {setProfileTitle} = useReduxActions()
    useEffect(() => { setProfileTitle("Урок: " + (data?.title ?? '...')) }, [data])

    return (
        <>
            <Setting 
                title={"Відео"} 
                actualData={data?.videoType}
                request={(values) => LessonService.updateVideoWithYoutube({lessonId: Number(id), ...values} as UpdateLessonVideoByUrlType)}
                onSuccess={(data) => setData(data)}
            >
                {(register) => <>
                    <DefaultInput icon={<VideoIcon />} placeholder="Силка на відео" {...register("youtubeLink")} />
                </>}
            </Setting>
            <Setting 
                title={"Назва"} 
                actualData={data?.title} 
                request={(values) => LessonService.updateTitle({lessonId: Number(id), ...values} as UpdateLessonTitleType)}
                onSuccess={(data) => setData(data)}
            >
                {(register) => <>
                    <DefaultInput icon={<SquarePenIcon />} defaultValue={data?.title} placeholder="Назва" {...register("title")} />
                </>}
            </Setting>
            <Setting 
                title={"Опис"}
                actualData={data?.description}
                request={(values) => LessonService.updateDescription({lessonId: Number(id), ...values} as UpdateLessonDescriptionType)}
                onSuccess={(data) => setData(data)}
            >
                {(register) => <>
                    <DefaultInput icon={<SquarePenIcon />} defaultValue={data?.description} placeholder="Опис" {...register("description")} />
                </>}
            </Setting>
            <Setting 
                title={"Домашня робота"} 
                actualData={data?.haveHomework ? 'Присутня' : 'Відсутня'}
                request={(values) => LessonService.updateHomework({lessonId: Number(id), ...values} as UpdateLessonHomeworkType)}
                onSuccess={(data) => setData(data)}
            >
                {(register, control) => <>
                    <Controller
                        control={control}
                        name={"status"}
                        render={({field: {onChange}}) => <SwitchCheckbox 
                            onLabel="вкл." 
                            offLabel="викл."
                            onChange={onChange}
                            defaultValue={data?.haveHomework} />}
                    />
                    <DefaultInput icon={<SquarePenIcon />} defaultValue={data?.homeworkDescription} placeholder="Опис домашньої роботи" {...register("description")} />
                </>}
            </Setting>
        </>
    )
}

export default LessonPage
